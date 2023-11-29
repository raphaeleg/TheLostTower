using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FenceController : MonoBehaviour
{
    [SerializeField] private UI_InputWindow inputWindow;
    public string code;
    public UnityEvent okAction;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactWithFence()
    {
        inputWindow.Show("Enter Password:", "", "1234567890", code, okAction);
    }

    public void onSuccess() {
        Destroy(gameObject);
    }
}
