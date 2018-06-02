using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life_controller : MonoBehaviour {

	private Image mImage;
	// Use this for initialization
	void Start () {
		mImage = GetComponent<Image> ();
	}
	
	public void setNewSprite(Sprite sp){
		mImage.sprite = sp;
	}
}
