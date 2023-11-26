using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public AudioClip soundEffect;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            InventoryItemController ic = eventData.pointerDrag.GetComponent<InventoryItemController>();
            
            if (ic.getTargetInteractable() == gameObject)
            {
                if (soundEffect != null)
                {
                    SoundManager.Instance.PlaySound(soundEffect);
                }
                ic.getInteractAction().Invoke();
            }
        }
    }

}
