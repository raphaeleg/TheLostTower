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
    public void GoToL2()
    {
        SceneManager.LoadScene("Floor2");
    }
    public void GoToL2Room()
    {
        SceneManager.LoadScene("Floor2Room");
    }
    public void GoToL3()
    {
        SceneManager.LoadScene("Floor3");
    }
    public void GoToL3Room()
    {
        SceneManager.LoadScene("Floor3Room");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Ending");
    }
}
