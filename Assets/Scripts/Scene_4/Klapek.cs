using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klapek : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!GlobalVariables.isPaused) {
			Vector3 dir = player.transform.position - transform.position;
 			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
 			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
			
	}
}
