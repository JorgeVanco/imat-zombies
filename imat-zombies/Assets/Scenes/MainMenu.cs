using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Juego");
    }

    public void LoadDifficultyScene()
    {
        SceneManager.LoadScene("Dificultad");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
