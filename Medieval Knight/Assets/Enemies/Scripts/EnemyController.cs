using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 1;

    public virtual void DamageEnemy(int damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(health);
    }
}
