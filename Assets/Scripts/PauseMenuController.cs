using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private FirstPersonController fps;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CloseMenu(GameObject closeObject)
    {
        closeObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        fps.cameraCanMove = true;
        fps.playerCanMove = true;
    }

    public void OpenMenu(GameObject openObject)
    {
        openObject.SetActive(true);
        fps.cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
        fps.playerCanMove = false;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.active == true)
            {
                CloseMenu(menu);
            }
            else
            {
                OpenMenu(menu);
            }
        }
    }
}
