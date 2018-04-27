using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController>();
	}
	
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "ground" && !player.isDashing) {
			player.isTouchingGround = true;
		}

		if (col.gameObject.tag == "Coin") {
			player.incrementMoney ();
			Destroy(col.gameObject);
		}

	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "ground" || player.isDashing) {
			player.isTouchingGround = false;
		}

		if (col.gameObject.tag == "Coin") {
		}
	}	
}
