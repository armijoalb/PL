using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

	public int damage = 1;

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.CompareTag ("enemy")) {
			Debug.Log (col.gameObject.tag);
			var enemy = col.gameObject.GetComponentInParent<slimeController> ();
			enemy.damageEnemy (damage);
		}
	}
}
