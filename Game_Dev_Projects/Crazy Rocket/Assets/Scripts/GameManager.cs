using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Called at the time of initialization
    private void Awake()
    {
        GameManagerSingleton();
    }

    private void GameManagerSingleton()
    {
        if (GameObject.FindObjectsOfType<GameManager>().Length > 1)
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

    // Go to Next level
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Go to Start level
    public void LoadStartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
