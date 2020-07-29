using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float splashScreenTime = 8f;
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        SceneLoaderSingleton();
    }

    void SceneLoaderSingleton()
    {
        if (GameObject.FindObjectsOfType<SceneLoader>().Length > 1)
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

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", splashScreenTime);
    }

    void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
