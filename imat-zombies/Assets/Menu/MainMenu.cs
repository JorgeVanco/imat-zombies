using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGameScene()
    {
        // Can't access MenuManager from here
        CursorLocker.LockCursor();
        SceneManager.LoadScene("Juego");
        Time.timeScale = 1f;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
