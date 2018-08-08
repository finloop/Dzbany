using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_bullet : MonoBehaviour {
	public float bulletSpeed = 100f;
	public string destroyOnCollisionTag = "Player";

	// Use this for initialization
	void Awake() {
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
	}
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * bulletSpeed);
	}
	
	// Update is called once per frame
	void Update () {
     
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {

	}
}
