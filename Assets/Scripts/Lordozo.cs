using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lordozo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Click");
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
