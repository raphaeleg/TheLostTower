using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject toReference;
    public UnityEvent toDo;
    public Canvas draggingOn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ListItems();
    }

    public void Add(Item item)
    {
        if (Items.Contains(item)) return;
        Items.Add(item);
        ListItems();
    }

    public void AddPuzzle(Item item, GameObject toReference, UnityEvent toDo)
    {
        if (Items.Contains(item)) return;
        Items.Add(item);
        ListItems();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.GetComponent<Image>();
            var itemDesc = obj.transform.GetChild(0).GetComponent<DialogueTrigger>();
            itemIcon.sprite = item.icon;
            itemIcon.preserveAspect = true;
            itemDesc.dialogue.conversation[0].dialogue = item.itemDesc;

            var iic = obj.transform.GetComponent<InventoryItemController>();
            if (iic == null) { continue; }
            iic.canvas = draggingOn;
            if (item.itemName != "A piece of a painting" && item.itemName != "Key") { continue; }
            iic.ToSlotIn = toReference;
            iic.interactAction = toDo;
        }
    }

    public bool PlayerHas(string nameToFind)
    {
        return Items.Any(i => i.itemName == nameToFind);
    }

    public Item GetItem(string nameToFind)
    {
        return Items.FirstOrDefault(i => i.itemName == nameToFind);
    }
}
