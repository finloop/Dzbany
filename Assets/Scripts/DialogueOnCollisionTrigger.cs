﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnCollisionTrigger : MonoBehaviour {

    DialogueTrigger dialogueTrigger;
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dialogueTrigger.TriggerDialogue();
    }
}