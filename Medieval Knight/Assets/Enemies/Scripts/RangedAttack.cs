using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {
    public float range;
    public GameObject arrow;
    public PlayerController player;
    public Transform launch;
    public float attackSpeed;
    private float shotCounter;
    public Animator anim;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        shotCounter = attackSpeed;
        anim = FindObjectOfType<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(new Vector3(transform.position.x - range, transform.position.y, transform.position.z), new Vector3(transform.position.x + range, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;
        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x <transform.position.x + range && shotCounter<0)
        {
            anim.SetBool("Attack", true);
            Instantiate(arrow, launch.position, launch.rotation);
            shotCounter = attackSpeed;
        }
        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - range && shotCounter < 0)
        {
            anim.SetBool("Attack", true);
            Instantiate(arrow, launch.position, launch.rotation);
            shotCounter = attackSpeed;
        }
    }
}
