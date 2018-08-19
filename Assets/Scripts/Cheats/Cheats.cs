using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour {

    private string[] cheatCode;
    private int index;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        cheatCode = new string[] { "p", "e", "p", "e", "l" };
        index = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown && !GlobalVariables.cheatMode)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length && !GlobalVariables.cheatMode)
        {
            Debug.Log("Cheat mode on");
            Dialogue d = new Dialogue();
            d.name = "The Creator";
            d.senetnces = new string[1];
            d.senetnces[0] = "Włączam tryb dla oszustów.";
            
            DialogueTrigger dialogueTrigger = new DialogueTrigger();
            dialogueTrigger.dialogueManager = GameObject.Find("Canvas/NarratorBox/NarratorManager").GetComponentInChildren<DialogueManager>();
            dialogueTrigger.dialogue = d;
            dialogueTrigger.TriggerDialogue();
            GlobalVariables.cheatMode = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Scenes/1");
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Scenes/2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Scenes/3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Scenes/4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Scenes/5");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Scenes/6");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Scenes/7");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("Scenes/8");
        }
    }
}
