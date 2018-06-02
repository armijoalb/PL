using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

	private GameObject PauseUI;
	private bool paused = false;
	public EventSystem es;
	private GameObject storeSelected;

	void Start(){
		PauseUI = GameObject.FindGameObjectWithTag ("pause_ui");
		PauseUI.SetActive (false);
		storeSelected = es.firstSelectedGameObject;
	}

	void Update(){
		bool pressedPause = Input.GetKeyDown (KeyCode.Escape) || Input.GetButtonDown ("StartButton");
		if (pressedPause) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}


		if (es.currentSelectedGameObject != storeSelected) {
			if (es.currentInputModule == null) {
				es.SetSelectedGameObject (storeSelected);
			} else {
				storeSelected = es.currentSelectedGameObject;
			}
		}
			
	}

	public void onResumeClicked(){
		PauseUI.SetActive (false);
		Time.timeScale = 1;
		paused = false;
	}

	public void onRestartClicked(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void onQuitClicked(){
		SceneManager.LoadScene ("StartMenu");
	}
}
