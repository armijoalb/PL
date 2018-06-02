using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {
    public float speed;
    public PlayerController player;
    public Rigidbody2D myrigidbody;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        myrigidbody = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x){
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        myrigidbody.velocity = new Vector2(speed, myrigidbody.velocity.y);
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("player"))
        {
            col.gameObject.GetComponent<PlayerController>().damage(1);
            Destroy(gameObject);
        }
    }
}
