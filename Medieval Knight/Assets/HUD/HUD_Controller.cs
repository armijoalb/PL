using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour {
	private PlayerController player_object;
	public Sprite[] hearth_sprites;
	private PlayerController player;
	private ArrayList completed_hearths = new ArrayList();
	private life_controller[] hearths;
	private int health;
	private bool gainedHealth;
	private bool loosedHealth;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController> ();

		hearths = GameObject.FindGameObjectWithTag ("hearth_hud").GetComponentsInChildren<life_controller> ();
		Debug.Log ("numero de corazones " + hearths.Length);


		for (int i = 0; i < player.maxHealth; i++) {
			completed_hearths.Add (1);
		}
		health = player.maxHealth;
		gainedHealth = false;
		loosedHealth = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < player.currentHealth) {
			gainedHealth = true;
		} else if (health > player.currentHealth) {
			loosedHealth = true;
		}

		health = player.currentHealth;

		if (gainedHealth) {
			gainedHealth = false;
			restoresHealth ();
		}

		if (loosedHealth) {
			loosedHealth = false;
			looseHealth ();
		}



	}

	void restoresHealth(){
		for (int i = 0; i < health; i++) {
			// Cambiar imagen a corazón lleno.
			completed_hearths[i] = 1;
			hearths [i].setNewSprite (hearth_sprites [0]);
		}
	}

	void looseHealth(){
		for (int i = completed_hearths.Count - 1; i >= health; i--) {
			// Cambiar imagen a corazón vacío.
			completed_hearths[i] = 0;
			Debug.Log (hearths.Length - 1 - i);
			hearths [i].setNewSprite (hearth_sprites [1]);
		}
	}

	void getHealth(){
		Debug.Log ("current health:" + health);
		if (loosedHealth) {
			Debug.Log ("loosed health");
		}

		if (gainedHealth) {
			Debug.Log ("gained health");
		}
	}
}
