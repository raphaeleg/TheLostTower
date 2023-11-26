using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public AudioClip scream;
    public Image blackScreen;
    public TMP_Text credits;
    bool finScream;

    float currAlpha;
    float t;
    public void Start()
    {
        float t = 230 / 255;
        float currAlpha = 230/255;
        bool finScream = false;

        //SoundManager.Instance.PlaySound(scream);
    }

    public void Update()
    {
        if (finScream)
        {
            StartCoroutine(creditScene());
        }
        else
        {
            blackScreen.color = new Color(0, 0, 0, Mathf.Lerp(currAlpha, 1f, t));
            t += 0.5f * Time.deltaTime;

            if (t > 1.0f)
            {
                finScream = true;
            }
        }
    }

    IEnumerator creditScene() {
        credits.color = Color.white;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }

}
