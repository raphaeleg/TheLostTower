using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;


    public void LoadNextLevel(string toLoadTo)
    {
        SceneManager.LoadScene(toLoadTo);
    }

    public void AnimateToNextLevel(string toLoadTo)
    {
        StartCoroutine(LoadLevel(toLoadTo));
    }

    IEnumerator LoadLevel(string toLoadTo)
    {
        // play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(toLoadTo);
    }
}
