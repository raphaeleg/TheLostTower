using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue currDialogue;
    public bool dialogueEnded;
    private Queue<string> sentences;

    private Queue<DialogueStructure> currentConversation;

    // UI
    public TMP_Text dialogueText;
    public Image spriteContainer;
    public Image dialogueContainer;

    void Start()
    {
        currentConversation = new Queue<DialogueStructure>();
        currDialogue = null;
        dialogueEnded = false;
    }

    public void StartDialogue(Dialogue conversation)
    {
        dialogueContainer.gameObject.SetActive(true);

        currentConversation.Clear();
        currDialogue = conversation;
        foreach (DialogueStructure sentence in conversation.conversation)
        {
            currentConversation.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentConversation.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueStructure sentence = currentConversation.Dequeue();

        dialogueContainer.gameObject.SetActive(false);
        spriteContainer.gameObject.SetActive(false);
        spriteContainer.color = Color.clear;

        if (sentence.sprite != null )
        {
            spriteContainer.sprite = sentence.sprite;
            spriteContainer.color = Color.white;
            spriteContainer.gameObject.SetActive(true);
        }
        if (!string.IsNullOrWhiteSpace(sentence.dialogue))
        {
            dialogueContainer.gameObject.SetActive(true);
            dialogueText.text = sentence.dialogue;
        }

    }

    void EndDialogue()
    {
        currDialogue = null;
        dialogueEnded = true;
        spriteContainer.gameObject.SetActive(false);
        spriteContainer.color = Color.clear;
        dialogueContainer.gameObject.SetActive(false);
    }
}
