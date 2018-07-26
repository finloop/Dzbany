using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    // Use this for initialization
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public void TriggerDialogue()
    {
        Debug.Log("Starting dialogue...");
        dialogueManager.StartDialogue(dialogue);
    }
}
