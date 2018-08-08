using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlappyMode : MonoBehaviour {
	public bool mode;
	public int speed;
	public int force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		Flappy_Movement.flappyMode = mode;
		Flappy_Movement.playerSpeed = speed;
		Flappy_Movement.playerJumpForce = force;
	}
}
