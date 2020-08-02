using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance { get; private set; }

    private void Awake()
    {
        if (GameObject.FindObjectsOfType<SceneHandler>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Load Game Scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    // Load Menu Scene
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    // Quit Application
    public void QuitGame()
    {
        Application.Quit();
    }
}
