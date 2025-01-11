using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        // Carga la escena del men� principal
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
