using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueStructure
{
    public Sprite sprite;
    public string name;
    public string dialogue;

    public DialogueStructure(Sprite sprite, string name, string dialogue)
    {
        this.sprite = sprite;
        this.name = name;
        this.dialogue = dialogue;
    }
}