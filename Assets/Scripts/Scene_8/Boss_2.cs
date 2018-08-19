using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour {
    public Animator start_phase1_animator;
    public GameObject player;
    public float time = 0.0f;
    public float interval = 0.8f;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // PHASE 1 HAS BEGUN
		if((start_phase1_animator != null) && start_phase1_animator.GetBool("isVisible"))
        {
            // DO PHASE 2 THINGS
            if(GetComponent<Enemy_Base>().health <= 700)
            {
                // do things once before phase 2
                if(!start_phase1_animator.GetBool("start2"))
                {
                    GameObject gameObject1 = GameObject.Find("KudiDial2");
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("EBullet");
                    GameObject[] objects1 = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject g in objects)
                    {
                        Destroy(g);
                    }
                    foreach (GameObject g in objects1)
                    {
                        Destroy(g);
                    }
                    gameObject1.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
                // start phase 2 / play phase 2 animation
                start_phase1_animator.SetBool("start2", true);

                // phase 2 stuff
                if (GetComponent<Enemy_Base>().health > 300) {
                    if (!GlobalVariables.isPaused)
                    {
                        interval = 1.5f;
                        Vector3 dir = player.transform.position - transform.position;
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                        time += Time.deltaTime;
                        if ((time >= interval))
                        {
                            GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Preclopies_a"), transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                            GameObject spawnedEnemy1 = Instantiate(Resources.Load("Prefabs/Preclopies_a"), transform.position, Quaternion.AngleAxis(angle+45, Vector3.forward)) as GameObject;
                            spawnedEnemy.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300f);
                            spawnedEnemy1.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 500f);

                            time = 0;
                        }
                    }
                }

                // phase 3 stuff
                if (GetComponent<Enemy_Base>().health <= 300)
                {

                    if(GetComponent<Enemy_Base>().health  <= 0)
                    {
                        GameObject[] objects = GameObject.FindGameObjectsWithTag("EBullet");
                        GameObject[] objects1 = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject g in objects) {
                            Destroy(g);
                        }
                        foreach (GameObject g in objects1)
                        {
                            Destroy(g);
                        }
                        GameObject.Find("KudiDial3").GetComponent<DialogueTrigger>().TriggerDialogue();
                        Destroy(gameObject);
                    }

                    if (!GlobalVariables.isPaused)
                    {
                        Vector3 dir = player.transform.position - transform.position;
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                        interval = 2f;
                        time += Time.deltaTime;
                        if ((time >= interval))
                        {
                            GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Preclopies_a"), transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                            GameObject spawnedEnemy2 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle - 30, Vector3.forward)) as GameObject;
                            GameObject spawnedEnemy3 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle + 30, Vector3.forward)) as GameObject;
                            GameObject spawnedEnemy4 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                            //GameObject spawnedEnemy5 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle + 10, Vector3.forward)) as GameObject;
                            spawnedEnemy.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 500f);
                            spawnedEnemy2.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300f);
                            spawnedEnemy3.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 200f);
                            spawnedEnemy4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 200f);
                            //spawnedEnemy5.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300f);

                            spawnedEnemy2.GetComponent<Basic_bullet>().damage = 20;
                            spawnedEnemy3.GetComponent<Basic_bullet>().damage = 20;
                            spawnedEnemy4.GetComponent<Basic_bullet>().damage = 20;
                            time = 0;
                        }
                    }
                }
            } else
            {
                // DO PHASE 1 THINGS
                // code

                // rotate boss towards player and shoot an object
                if (!GlobalVariables.isPaused)
                {
                    Vector3 dir = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    time += Time.deltaTime;
                    if ((time >= interval))
                    {
                        GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Preclopies_a"), transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                        spawnedEnemy.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300f);

                        time = 0;
                    }
                }
            }
        }
	}
}
