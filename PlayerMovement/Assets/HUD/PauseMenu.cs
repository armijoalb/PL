using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	private GameObject PauseUI;
	private bool paused = false;


	void Start(){
		PauseUI = GameObject.FindGameObjectWithTag ("pause_ui");
		PauseUI.SetActive (false);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
			
	}

	public void onResumeClicked(){
		PauseUI.SetActive (false);
		Time.timeScale = 1;
		paused = false;
	}

	public void onRestartClicked(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void onQuitClicked(){
		Application.Quit ();
	}
}
