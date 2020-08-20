using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;

    public void LoadGameOverCanvas()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
