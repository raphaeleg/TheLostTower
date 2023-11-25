using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    public GameObject choiceContainer;
    public Button choiceBtn;
    public ChoiceStructure[] choices;

    public void Start()
    {
        foreach (ChoiceStructure choice in choices)
        {
            Button temp = Instantiate(choiceBtn, choiceContainer.transform);
            temp.GetComponentInChildren<TMP_Text>().text = choice.description;
            temp.onClick.AddListener(delegate {
                choice.toTrigger.setTrigger(true);
                choiceContainer.SetActive(false);
                for (var i = choiceContainer.transform.childCount - 1; i >= 0; i--)
                {
                    Object.Destroy(choiceContainer.transform.GetChild(i).gameObject);
                }

            });
        }
    }

    public void Trigger()
    {
        choiceContainer.SetActive(true);
        gameObject.SetActive(true);
    }
}
