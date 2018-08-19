using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Back : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToGame()
    {
        SceneManager.LoadScene("Scenes/main_screen");
    }
}
