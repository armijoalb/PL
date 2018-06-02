using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_hud_controller : MonoBehaviour {
	private PlayerController player;
	private Text text_counter;
	private int current_money_displayed;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
		text_counter = GameObject.FindGameObjectWithTag ("coin_counter").GetComponent<Text> ();
		current_money_displayed = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (current_money_displayed != player.getMoney ()) {
			current_money_displayed = player.getMoney ();
			text_counter.text = current_money_displayed.ToString ();
		}
	}
}
