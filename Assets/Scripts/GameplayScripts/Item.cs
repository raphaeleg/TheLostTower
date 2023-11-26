using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName="New Item", menuName="Item/Create New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string itemDesc;
}
