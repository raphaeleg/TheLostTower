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
    public AudioClip successAudio;
    private int LIMITED_INPUT_LENGTH = 4;

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
            return ValidateChar(validCharacters, addedChar, text);
        };
        inputField.text = inputString;

        okBtn.onClick.AddListener(() => {
            if (inputField.text == code) {
                okAction.Invoke();
                if (successAudio != null)
                {
                    SoundManager.Instance.PlaySound(successAudio);
                }
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

    private char ValidateChar(string validCharacters, char addedChar, string inputString)
    {
        if (validCharacters.IndexOf(addedChar) != -1 && inputString.Length < LIMITED_INPUT_LENGTH)
        {
            return addedChar;
        }
        return '\0';
    }
}
