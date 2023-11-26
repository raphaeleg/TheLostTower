using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGuideline : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) )
        {
            Destroy(gameObject);
        }
    }
}
