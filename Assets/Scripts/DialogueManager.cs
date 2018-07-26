using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator nextAnimator;
    public DialogueTrigger nextDialogue;
    public string trigger;
    public string message;
    public float letterPaused = 0.01f;
    private bool isFinishedDisp = true;

    // Update is called once per frame
    void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        if (!GlobalVariables.isDialogueHappening)
        {
            animator.SetBool(trigger, true);
            nameText.text = dialogue.name;
            // Delete stored sentences
            sentences.Clear();
            nextAnimator = dialogue.nextAnimator;
            // Add all sentences to the queue
            foreach (string sentence in dialogue.senetnces)
            {
                sentences.Enqueue(sentence);
            }

            // Display first sentence in a queue
            nextDialogue = dialogue.nextDialogue;
            DisplayNextSentence();
            GlobalVariables.isDialogueHappening = true;
            
        }
    }

    // Displays next sentence in a queue
    public void DisplayNextSentence()
    {
        if(isFinishedDisp)
        {
            // ends dialogue if theres no sentences left
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            message = sentences.Dequeue();
            dialogueText.text = "";
            StartCoroutine(TypeText());
        }
    }

    public void EndDialogue()
    {
        animator.SetBool(trigger, false);
        GlobalVariables.isDialogueHappening = false;
        if(nextAnimator != null)
        {
            nextAnimator.SetBool("isVisible", true);
            nextAnimator = null;
        }

        if (nextDialogue != null)
        {
            nextDialogue.TriggerDialogue();
        }

    }


    IEnumerator TypeText()
    {
        isFinishedDisp = false;
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            //Add 1 letter each
            dialogueText.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
        isFinishedDisp = true;
    }

}
