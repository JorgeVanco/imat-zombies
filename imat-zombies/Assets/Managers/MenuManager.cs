using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeToScene(string sceneName, bool additive=false) {
        if (sceneName == "Juego")
        {
            CursorLocker.LockCursor();
            Time.timeScale = 1f;
        }
        else {
            CursorLocker.UnLockCursor();
        }

        if (additive) {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void UnloadScene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
