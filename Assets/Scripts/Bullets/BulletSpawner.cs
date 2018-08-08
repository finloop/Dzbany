using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
	public GameObject bullet;
	public bool isSpawning = true;
	public float interval = 0.5f;
	public bool spawnAtStart = true;
	private float time = 0.0f;
	// Use this for initialization
	void Start () {
		if(spawnAtStart) {
			GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Bullet"),transform.position, transform.rotation) as GameObject;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(isSpawning& (time >= interval)) {
			GameObject spawnedEnemy = Instantiate(Resources.Load("Prefabs/Bullet"),transform.position, transform.rotation) as GameObject;
			time = 0;	
		}
		
	}

}
