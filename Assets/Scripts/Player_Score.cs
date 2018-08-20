using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerRespawn"))
        {
            int i = GlobalVariables.scenes_positions.FindIndex(x => x.Key.Equals(gameObject.scene.name));
            if(i == -1)
                GlobalVariables.scenes_positions.Add(new KeyValuePair<string, Vector3>(gameObject.scene.name, gameObject.transform.position));
            else
                GlobalVariables.scenes_positions[i] = new KeyValuePair<string, Vector3>(gameObject.scene.name, gameObject.transform.position);

            gameObject.GetComponent<Player_Health>().RestoreHealth();
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag.Equals("DialogueTrigger"))
        {
            int i = GlobalVariables.scenes_positions.FindIndex(x => x.Key.Equals(gameObject.scene.name));
            if(i == -1)
                GlobalVariables.scenes_positions.Add(new KeyValuePair<string, Vector3>(gameObject.scene.name, gameObject.transform.position));
            else
                GlobalVariables.scenes_positions[i] = new KeyValuePair<string, Vector3>(gameObject.scene.name, gameObject.transform.position);
            collision.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(collision.gameObject);
        }
    }
}
