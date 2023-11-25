using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ChoiceStructure
{
    public string description;
    public DialogueTrigger toTrigger;

    public ChoiceStructure(string desc, DialogueTrigger trig)
    {
        this.description = desc;
        this.toTrigger = trig;
    }
}