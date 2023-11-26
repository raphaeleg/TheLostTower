using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    public GameObject paintingComp;
    public Item paintingPiece;
    public void onSuccess()
    {
        paintingComp.SetActive(true);
        gameObject.SetActive(true);
        InventoryManager.Instance.Remove(paintingPiece);
        Destroy(gameObject);
    }
}
