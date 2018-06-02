using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_something : MonoBehaviour {

	public GameObject projectile;
	public Vector2 velocity;
	private bool canShoot = true;
	public Vector2 offset = new Vector2 (0.5f, 0.1f);
	public float cooldown = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool shootDown = Input.GetKeyDown (KeyCode.G) || Input.GetButtonDown ("B_Button");
		if (shootDown && canShoot) {
			StartCoroutine (CanShoot ());
			Debug.Log (transform.localScale.x);
		
			GameObject go = (GameObject) Instantiate (projectile,
				(Vector2) transform.position + offset * transform.localScale.x,
				Quaternion.identity);
			if (transform.localScale.x == -1)
				go.transform.localScale = new Vector3 (-1f, 1f, 1f);
			go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y) * transform.localScale.x;

		}
	}

	IEnumerator CanShoot(){
		canShoot = false;
		yield return new WaitForSeconds (cooldown);
		canShoot = true;
	}
}
