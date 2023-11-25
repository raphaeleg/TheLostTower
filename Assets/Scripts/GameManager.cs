using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Beginning");
    }
    public void GoToL1()
    {
        SceneManager.LoadScene("Floor1");
    }
}
