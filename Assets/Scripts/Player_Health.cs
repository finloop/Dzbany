using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < -15)
        {
            SceneManager.LoadScene("Scenes/youdied");
        }
        Debug.Log(transform.position.y);
	}
}
