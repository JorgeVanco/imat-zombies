using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        CursorLocker.UnLockCursor();
    }

    public void LoadMainMenu()
    {
        // Carga la escena del men� principal
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
