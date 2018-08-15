using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    public GameObject player;
    public Animator phase1_animator;
    public bool phase1_bool;
    public int phase1_health;
    public bool isSpawning = false;
    public float interval = 0.1f;
    public bool spawnAtStart = true;
    private float time = 0.0f;
    private bool startPhase1 = true;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Enemy_Base>().health <= phase1_health)
        {
            if (startPhase1)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                startPhase1 = !startPhase1;
                isSpawning = true;
            }
            // ACTIVATE PHASE 1

            if (!GlobalVariables.isPaused)
            {
                Vector3 dir = player.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                time += Time.deltaTime;
                if (isSpawning & (time >= interval))
                {
                    GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
                    GameObject spawnedEnemy1 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle+45, Vector3.forward)) as GameObject;
                    GameObject spawnedEnemy2 = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.AngleAxis(angle-45, Vector3.forward)) as GameObject;

                    time = 0;
                }
            }

        }
        gameObject.GetComponent<Animator>().SetInteger("health", GetComponent<Enemy_Base>().health);
        if(GetComponent<Enemy_Base>().health <= 0) {
            GameObject exit = GameObject.Find("Exit");
            exit.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(34);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(34);
        }

    }
}
