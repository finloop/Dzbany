using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klapek_Spawner : MonoBehaviour {
	public bool isSpawning = true;
	public float interval = 0.5f;
	public bool spawnAtStart = true;
	private float time = 0.0f;
	public float bulletSpeed = 100f;
	public string destroyOnCollisionTag = "Player";
	// Use this for initialization
	void Start () {
		if(spawnAtStart) {
			GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Scene_4/Bullet"),transform.position, transform.rotation) as GameObject;
			spawnedEnemy.GetComponent<Rigidbody2D>().gravityScale = 0;
			spawnedEnemy.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(isSpawning& (time >= interval)) {
			GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Scene_4/Bullet"),transform.position, transform.rotation) as GameObject;
			spawnedEnemy.GetComponent<Rigidbody2D>().gravityScale = 0;
			spawnedEnemy.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed);
			time = 0;	
		}
		
	}

}
