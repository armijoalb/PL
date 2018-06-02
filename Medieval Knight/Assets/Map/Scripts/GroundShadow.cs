using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShadow : MonoBehaviour {

    private bool damaged = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            if (!damaged)
            {
                collision.gameObject.GetComponent<PlayerController>().damage(1);
                damaged = true;
            }

        }
    }
}
