using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_trigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){

		if (!col.CompareTag ("player")) {
			if (col.CompareTag ("enemy")) {
				var enemy = col.gameObject.GetComponentInParent<EnemyController> ();
				enemy.DamageEnemy (2);
				Destroy (gameObject);
			} else if (!col.CompareTag ("Coin") && !col.CompareTag("arrow")) {
				Destroy (gameObject);
			}



		}
	} 
}
