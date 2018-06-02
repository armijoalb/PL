using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : EnemyController {

    public GameObject magicBall;
    public GameObject fireBall;
    public GameObject groundShadow;
    public GameObject groundAcid;
    public GameObject player;

    public Transform fireLoc;
    public Transform[] shadowLoc;
    public Transform[] acidLoc;
    public Transform[] tpLoc;
    public Transform[] magicLoc;
    

    private bool fase1 = true;
    private bool fase2 = false;
    private bool fase3 = false;
    private bool shadowAttack = false;
    private bool acidAttack = false;
    private bool magicAttack = false;
    private bool fireAttack = false;
    private bool idle = true;

    private int maxHealth;
    private int golpes = 0;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = health;
    }

    protected void Update()
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }

        if(fase1)
        {
            if(idle)
            {
                idle = false;
                StartCoroutine(IDLE());
            }

            if(shadowAttack)
            {
                shadowAttack = false;

                int index = 0;
                float distance = 100;
                float new_distance = 0;
                List<Vector3> shadowPos = new List<Vector3>();
                Vector3 pos;
                
                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    shadowPos.Add(shadowLoc[i].position);
                }
                
                
                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    distance = 100;
                    for (int j = 0; j < shadowPos.Count; j++)
                    {
                        new_distance = (player.transform.position - shadowPos[j]).magnitude;
                        Debug.Log(new_distance);

                        if (new_distance < distance)
                        {
                            distance = new_distance;
                            index = j;
                            Debug.Log(index);
                        }
                        
                    }
                    pos = shadowPos[index];
                    StartCoroutine(ShadowAttack(pos, i));
                    shadowPos.RemoveAt(index);

                }
                
            }

            if(acidAttack)
            {
                acidAttack = false;
                float distance1 = 0, distance2 = 0;

                distance1 = (player.transform.position - acidLoc[0].position).magnitude;
                distance2 = (player.transform.position - acidLoc[acidLoc.Length-1].position).magnitude;

                if(distance1 <= distance2)
                {
                    for(int i = 0; i < acidLoc.Length; i++)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], i));
                    }
                }
                else
                {
                    int index = 0;
                    for (int i = acidLoc.Length - 1; i >= 0; i--)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], index));
                        index++;
                    }
                }
            }
        }

        if(fase2)
        {
            if (idle)
            {
                idle = false;
                StartCoroutine(IDLE());
            }

            if (shadowAttack)
            {
                shadowAttack = false;

                int index = 0;
                float distance = 100;
                float new_distance = 0;
                List<Vector3> shadowPos = new List<Vector3>();
                Vector3 pos;

                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    shadowPos.Add(shadowLoc[i].position);
                }


                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    distance = 100;
                    for (int j = 0; j < shadowPos.Count; j++)
                    {
                        new_distance = (player.transform.position - shadowPos[j]).magnitude;
                        Debug.Log(new_distance);

                        if (new_distance < distance)
                        {
                            distance = new_distance;
                            index = j;
                            Debug.Log(index);
                        }

                    }
                    pos = shadowPos[index];
                    StartCoroutine(ShadowAttack(pos, i));
                    shadowPos.RemoveAt(index);

                }

            }

            if (acidAttack)
            {
                acidAttack = false;
                float distance1 = 0, distance2 = 0;

                distance1 = (player.transform.position - acidLoc[0].position).magnitude;
                distance2 = (player.transform.position - acidLoc[acidLoc.Length - 1].position).magnitude;

                if (distance1 <= distance2)
                {
                    for (int i = 0; i < acidLoc.Length; i++)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], i));
                    }
                }
                else
                {
                    int index = 0;
                    for (int i = acidLoc.Length - 1; i >= 0; i--)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], index));
                        index++;
                    }
                }
            }

            if(fireAttack)
            {
                fireAttack = false;
                StartCoroutine(FireAttack());
            }

            if(magicAttack)
            {
                magicAttack = false;
                StartCoroutine(MagicAttack1(magicLoc[0]));
                
            }
        }

        if(fase3)
        {
            if (idle)
            {
                idle = false;
                StartCoroutine(IDLE());
            }

            if (shadowAttack)
            {
                shadowAttack = false;

                int index = 0;
                float distance = 100;
                float new_distance = 0;
                List<Vector3> shadowPos = new List<Vector3>();
                Vector3 pos;

                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    shadowPos.Add(shadowLoc[i].position);
                }


                for (int i = 0; i < shadowLoc.Length; i++)
                {
                    distance = 100;
                    for (int j = 0; j < shadowPos.Count; j++)
                    {
                        new_distance = (player.transform.position - shadowPos[j]).magnitude;
                        Debug.Log(new_distance);

                        if (new_distance < distance)
                        {
                            distance = new_distance;
                            index = j;
                            Debug.Log(index);
                        }

                    }
                    pos = shadowPos[index];
                    StartCoroutine(ShadowAttack(pos, i));
                    shadowPos.RemoveAt(index);

                }

            }

            if (acidAttack)
            {
                acidAttack = false;
                float distance1 = 0, distance2 = 0;

                distance1 = (player.transform.position - acidLoc[0].position).magnitude;
                distance2 = (player.transform.position - acidLoc[acidLoc.Length - 1].position).magnitude;

                if (distance1 <= distance2)
                {
                    for (int i = 0; i < acidLoc.Length; i++)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], i));
                    }
                }
                else
                {
                    int index = 0;
                    for (int i = acidLoc.Length - 1; i >= 0; i--)
                    {
                        StartCoroutine(AcidAttack(acidLoc[i], index));
                        index++;
                    }
                }
            }

            if(magicAttack)
            {
                magicAttack = false;

                for(int i = 0; i < magicLoc.Length; i++)
                {
                    StartCoroutine(MagicAttack2(magicLoc[i], i));
                }
            }
        }
    }


    public override void DamageEnemy(int damage)
    {
        float distance = 0;
        float new_distance = 0;
        int tp = 0;

        health -= damage;
        golpes++;

        if (this.health <= 0 && fase1)
        {
            fase1 = false;
            fase2 = true;
            health = maxHealth;
            animator.SetTrigger("Fase2");
            shadowAttack = false;
            acidAttack = false;
            magicAttack = true;
            fireAttack = true;
            idle = true;

        }

        if (this.health <= 0 && fase2)
        {
            fase2 = false;
            fase3 = true;
            health = maxHealth;
            animator.SetTrigger("Fase3");
            shadowAttack = false;
            acidAttack = false;
            magicAttack = true;
            fireAttack = false;
            idle = true;
        }

        if (this.health <= 0 && fase3)
        {
            Destroy(this.gameObject);
        }

        if(golpes >= 3)
        {
            for (int i = 0; i < tpLoc.Length; i++)
            {
                new_distance = (player.transform.position - tpLoc[i].position).magnitude;
                if (new_distance > distance)
                {
                    distance = new_distance;
                    tp = i;
                }
            }

            this.transform.position = tpLoc[tp].position;
            golpes = 0;

        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log ("collides with: " + col.gameObject.tag);
        if (col.gameObject.CompareTag("player"))
        {
            col.gameObject.GetComponent<PlayerController>().damage(1);
        }
    }

    IEnumerator ShadowAttack(Vector3 pos, int i)
    {

        yield return new WaitForSeconds(((float)i)*0.5f);
        Instantiate(groundShadow, pos, Quaternion.identity);
        if (i == 10)
        {
            acidAttack = true;
        }

    }

    IEnumerator AcidAttack(Transform pos, int index)
    {

        yield return new WaitForSeconds(((float)index) * 0.5f);
        Instantiate(groundAcid, pos.position, Quaternion.identity);
        if (index == 7)
        {
            idle = true;
        }

    }

    IEnumerator MagicAttack1(Transform pos)
    {

        yield return new WaitForSeconds(10f);
        if(fase2)
        {
            Instantiate(magicBall, pos.position, Quaternion.identity);

            magicAttack = true;

        }
        

    }

    IEnumerator MagicAttack2(Transform pos, int index)
    {

        yield return new WaitForSeconds(((float)index)+1 * 5f);
        Instantiate(magicBall, pos.position, Quaternion.identity);
        Debug.Log(index);
        if(index == 3)
        {
            magicAttack = true;
        }
        

    }

    IEnumerator FireAttack()
    {
        
        yield return new WaitForSeconds(5f);
        if(fase2)
        {
            Instantiate(fireBall, fireLoc.position, Quaternion.identity);
            fireAttack = true;
        }
        
    }

    IEnumerator IDLE()
    {

        yield return new WaitForSeconds(6f);
        shadowAttack = true;

    }
}
