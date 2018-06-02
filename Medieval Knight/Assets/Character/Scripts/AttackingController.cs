using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingController : MonoBehaviour {
	private bool attack = false;
	private float attackTimer = 0;
	private float attackCooldown = 0.3f;
	private Animator animator;
	public Collider2D trigger;

	void Awake(){
		animator = gameObject.GetComponent<Animator> ();
		trigger.enabled = false;
	}

	void Update(){
		bool isAttackPressed = Input.GetKeyDown (KeyCode.F) || Input.GetButtonDown("X_Button");

		if (isAttackPressed) {
			attack = true;
			attackTimer = attackCooldown;
			trigger.enabled = true;
		}

		if (attack) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attack = false;
				trigger.enabled = false;
			}
		}

		animator.SetBool ("isAttacking", attack);
	}
}
