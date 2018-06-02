using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public int levelToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
			if(Input.GetKeyDown("e") || Input.GetButtonDown("Y_Button") )
            {
                SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
            }
        }
    }

}
