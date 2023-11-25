using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public bool isTriggerable;
    public Dialogue dialogue;
    public Choice afterDialogueChoice;
    public string afterDialogueChangeSceneTo;
    private DialogueManager dm;

    public void Awake()
    {
        dm = FindObjectOfType<DialogueManager>();
        if (!isTriggerable)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        if (isTriggerable)
        {
            isTriggering();
        }
    }

    public void setTrigger(bool toSet)
    {
        isTriggerable = toSet;
        gameObject.SetActive(toSet);
        if (toSet ) {
            isTriggering();
        }
    }

    public void isTriggering()
    {
        if (!isTriggerable)
        {
            return;
        }

        if (dm.currDialogue is null)
        {
            if (!dm.dialogueEnded)
            {
                dm.StartDialogue(dialogue);
            }
            else
            {
                isTriggerable = false;
                dm.dialogueEnded = false;
                if (afterDialogueChoice is not null)
                {
                    afterDialogueChoice.Trigger();
                }
                else if (!string.IsNullOrWhiteSpace(afterDialogueChangeSceneTo))
                {
                    SceneManager.LoadScene(afterDialogueChangeSceneTo);
                }
                
            }

        }
        else if ((Input.GetMouseButtonDown(0)))
        {
            dm.DisplayNextSentence();
        }
        
    }
}
