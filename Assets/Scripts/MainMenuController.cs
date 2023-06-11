using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("выход из игры");
    }

    public void CloseWindow(GameObject closeObject)
    {
        closeObject.SetActive(false);
    }

    public void OpenWindow(GameObject openObject)
    {
        openObject.SetActive(true);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
