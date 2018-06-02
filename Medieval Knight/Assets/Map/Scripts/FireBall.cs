using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private GameObject player;

    public float speed = 1f;

    private Vector3 direction;

    private void Awake()
    {
        player = GameObject.Find("Player");
        if(player == null)
        {
            player = GameObject.Find("Player (3)");
        }
        
    }

    private void Start()
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            direction = player.transform.position - this.transform.position;
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Vector3.Angle(direction, new Vector3(0, -1, 0)));

        }
        else
        {
            direction = player.transform.position - this.transform.position;
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, -Vector3.Angle(direction, new Vector3(0, -1, 0)));

        }
    }

    private void Update () {

        
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            collision.gameObject.GetComponent<PlayerController>().damage(2);
            Destroy(this.gameObject);

        }
    }

}
