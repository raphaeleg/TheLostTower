using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryItemController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //[SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 ogPosition;
    public GameObject ToSlotIn;
    public UnityEvent interactAction;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ogPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;// canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        ResetPosition();
    }

    public GameObject getTargetInteractable()
    {
        return ToSlotIn;
    }

    public UnityEvent getInteractAction()
    {
        return interactAction;
    }

    public void ResetPosition()
    {
       rectTransform.anchoredPosition = ogPosition;
    }
}
