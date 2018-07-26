using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //[TextArea(2,10)]
    public string[] senetnces;
    public string name;
    public Animator nextAnimator;
    public DialogueTrigger nextDialogue;
}
