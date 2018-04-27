using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 20f;
	public float MaxSpeed = 5f;
	private Rigidbody2D mBody;
	private Animator animator;
	public bool isTouchingGround;
	public float jumpPower = 6.5f;
	private bool jump;
	private bool doubleJump;
	private bool isJumping;
	public bool isDashing;

	public int maxHealth = 5;
	private int money = 0;
	public int currentHealth;
	public Canvas ui_manager;

	// Use this for initialization
	void Start () {
		mBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("Speed",Mathf.Abs(mBody.velocity.x));
		animator.SetBool("isTouchingGround",isTouchingGround);
		animator.SetBool ("isDashing", isDashing);

		bool isJumpPressed = Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space);

		if (isJumpPressed && isTouchingGround) {
			jump = true;
		} else if (isJumpPressed && isJumping) {
			doubleJump = true;
		}


		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		} else if (currentHealth <= 0) {
			Die ();
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			currentHealth--;
		}

		if(Input.GetKeyDown(KeyCode.L) ){
			if( currentHealth < maxHealth)
				currentHealth++;
		}
	}

	// Utilizar este en vez del Update.
	void FixedUpdate(){

		Vector3 fixedVelocity = mBody.velocity;
		fixedVelocity.x *= 0.75f;

		if (isTouchingGround && !isDashing) {
			mBody.velocity = fixedVelocity;
		}

		float h = Input.GetAxis("Horizontal");
		mBody.AddForce(Vector2.right*Speed*h);
		float limitedSpeed = Mathf.Clamp(mBody.velocity.x,-MaxSpeed,MaxSpeed);
		if (!isDashing) {
			mBody.velocity = new Vector2 (limitedSpeed, mBody.velocity.y);
		}

		if (h > 0.1f) {
			mBody.transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (h < -0.1f) {
			mBody.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (jump) {
			mBody.velocity = new Vector2 (mBody.velocity.x, 0);
			mBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
			isJumping = true;
		}

		if(doubleJump){
			mBody.velocity = new Vector2 (mBody.velocity.x, 0);	
			mBody.AddForce (Vector3.up * 300f);
			isJumping = false;
			doubleJump = false;
		}


			
	}

	void Die(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void incrementMoney(){
		money++;
	}

	public int getMoney(){
		return money;
	}

	public void damage(int damage){
		Debug.Log ("me han hecho daño");
		currentHealth -= damage;
	}
}
