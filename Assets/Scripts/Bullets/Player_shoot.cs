using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{

    public bool isSpawning = true;
    public float interval = 0.3f;
    public bool spawnAtStart = true;
    private float time = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (!GlobalVariables.isPaused)
            {

                if (isSpawning & (time >= interval))
                {
					var mouse = Input.mousePosition;
             		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
             		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
             		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
                    GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Players_bullet"), transform.position, Quaternion.Euler(0, 0, angle)) as GameObject;
                    time = 0;
                }
            }
        }
    }
}
