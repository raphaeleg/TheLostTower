using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        if (dm.currDialogue is not null)
        {
            Debug.Log("In");
            dm.DisplayNextSentence();
        }
        else
        {
            Debug.Log("Start");
            dm.StartDialogue(dialogue);
        }
    }
}
