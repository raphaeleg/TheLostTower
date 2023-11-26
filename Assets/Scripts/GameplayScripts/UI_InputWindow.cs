using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UI_InputWindow : MonoBehaviour
{
    public Button okBtn;
    public Button cancelBtn;
    public TMP_Text titleText;
    public TMP_InputField inputField;

private void Awake()
    {
        Hide();
    }
    public void Show(string titleString, string inputString, string validCharacters, string code, UnityEvent okAction)
    {
        gameObject.SetActive(true);

        titleText.text = titleString;
        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };
        inputField.text = inputString;

        okBtn.onClick.AddListener(() => {
            Debug.Log(code+" "+inputField.text);
            if (inputField.text == code) {
                okAction.Invoke();
                Hide();
            }
            else
            {
                inputField.text = "";
                inputString = "";
            }
        });
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        return '\0';
    }
}
