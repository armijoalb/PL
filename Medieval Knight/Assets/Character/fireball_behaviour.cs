using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyFireball ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator destroyFireball(){
		yield return new WaitForSeconds (5);
		Destroy (gameObject);
	}
}
