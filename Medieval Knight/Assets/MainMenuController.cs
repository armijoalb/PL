using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour {

	public EventSystem es;
	private GameObject storeSelected;

	void Start(){
		storeSelected = es.firstSelectedGameObject;
	}

	void Update(){
		if (es.currentSelectedGameObject != storeSelected) {
			if (es.currentInputModule == null) {
				es.SetSelectedGameObject (storeSelected);
			} else {
				storeSelected = es.currentSelectedGameObject;
			}
		}
	}

	public void PlayGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitGame(){
		Application.Quit ();
	}




}
