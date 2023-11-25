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
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image spriteContainer;
    public Image dialogueContainer;
    public Image nameContainer;

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

        spriteContainer.gameObject.SetActive(false);
        nameContainer.gameObject.SetActive(false);

        if (!string.IsNullOrWhiteSpace(sentence.name))
        {
            nameText.text = sentence.name;
            nameContainer.gameObject.SetActive(true);
        }
        if (sentence.sprite is not null)
        {
            spriteContainer = sentence.sprite;
            spriteContainer.gameObject.SetActive(true);
        }

        dialogueText.text = sentence.dialogue;
    }

    void EndDialogue()
    {
        currDialogue = null;
        dialogueEnded = true;
        spriteContainer.gameObject.SetActive(false);
        nameContainer.gameObject.SetActive(false);
        dialogueContainer.gameObject.SetActive(false);
    }
}
