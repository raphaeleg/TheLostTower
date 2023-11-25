using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private InventoryManager im;
    public bool isLocked = true;

    public void OpenDoor()
    {
        im = FindObjectOfType<InventoryManager>();
        if (im == null)
        {
            return;
        }
        if (im.PlayerHas("Key"))
        {
            isLocked = false;
            im.Remove(im.GetItem("Key"));
            SceneManager.LoadScene("Floor1");
        }
    }
}
