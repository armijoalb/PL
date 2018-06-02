using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public GameObject fireBall;
    public GameObject player;
    public Transform fireSpawn;
    public Animator animator;

    public float maxSpeed = 1f;
    public float speed = 1f;

    private bool isDead = false;
    private bool isAttacking = false;
    private bool isMoving = true;

    private Rigidbody2D rb2d;
	public GameObject door;


    // Use this for initialization
    protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }

        if(isMoving)
        {
            isMoving = false;
            animator.SetBool("Attacking", isAttacking);
            StartCoroutine(Moving());
        }

        if(isAttacking)
        {
            isAttacking = false;
            animator.SetBool("Moving", isMoving);

            StartCoroutine(Attacking());
        }

        
		
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
        if(!isDead)
        {
            rb2d.AddForce(Vector2.right * speed);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
            {
                speed = -speed;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
        }
        else
        {
            speed = 0;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        
        
        
        
        /*
        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        */
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log ("collides with: " + col.gameObject.tag);
        if (col.gameObject.CompareTag("player"))
        {
            col.gameObject.GetComponent<PlayerController>().damage(1);
        }
    }

    public override void DamageEnemy(int damage)
    {        
        health -= damage;
        Debug.Log("override");
        if (this.health <= 0)
        {
            isDead = true;
            isMoving = false;
            isAttacking = false;
            door.SetActive(true);
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        animator.SetBool("Dead", isDead);
        yield return new WaitForSeconds(5f);
        Debug.Log("me muero");
        Destroy(this.gameObject);
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(fireBall, fireSpawn.position, Quaternion.identity);
        isMoving = true;
        animator.SetBool("Moving", isMoving);
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(5f);
        isAttacking = true;
        animator.SetBool("Attacking", isAttacking);
    }
    
    
}
