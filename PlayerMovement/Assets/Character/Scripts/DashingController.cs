using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DashState{
	Ready,
	Dashing,
	Cooldown
}

public class DashingController : MonoBehaviour {

	private PlayerController player;
	private Rigidbody2D body;
	public DashState state;
	public float dashTimer;
	public float maxDash = 1f;
	public Vector2 savedVel;
	private float MaxSpeed = 5f;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController> ();
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case DashState.Ready:
			bool isDashPressed = Input.GetKeyDown (KeyCode.LeftShift);
			if (isDashPressed) {
				savedVel = body.velocity;
				float limitedSpeed = Mathf.Clamp(body.velocity.x*1.5f,-MaxSpeed,MaxSpeed);
				body.velocity = new Vector2 (limitedSpeed, body.velocity.y);
				state = DashState.Dashing;
				player.isDashing = true;
			}
			break;

		case DashState.Cooldown:
			dashTimer -= Time.deltaTime*15;
			if (dashTimer <= 0) {
				dashTimer = 0;
				state = DashState.Ready;
			}
			player.isDashing = false;
			break;

		case DashState.Dashing:
			dashTimer += Time.deltaTime * 90;
			if (dashTimer >= maxDash) {
				dashTimer = maxDash;
				body.velocity = savedVel;
				state = DashState.Cooldown;
				player.isDashing = false;
			}
			break;
		}

		
	}
}
