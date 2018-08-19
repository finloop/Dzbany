using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour {
    public Animator start_phase1_animator;
    public GameObject player;
    public float time = 0.0f;
    public float interval = 1.0f;
   
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
                    gameObject1.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
                // start phase 2 / play phase 2 animation
                start_phase1_animator.SetBool("start2", true);

                // phase 2 stuff


                if (GetComponent<Enemy_Base>().health <= 300)
                {

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
