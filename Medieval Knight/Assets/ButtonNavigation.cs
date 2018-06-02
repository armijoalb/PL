using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigation : MonoBehaviour {
	int index = 0;
	public int totalOptions = 3;
	public float yOffset = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("RightJoystickVertical") < 0) {
			if (index < totalOptions - 1) {
				index++;
			}
		}

		if (Input.GetAxis ("RightJoystickVertical") > 0) {
			if (index > 0) {
				index--;
			}
				
		}
		
	}
}
