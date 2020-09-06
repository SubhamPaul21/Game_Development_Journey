using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject GameMenu;
    [SerializeField] GameObject EndMenu;
    
    [Tooltip("Minutes in second format")]
    [SerializeField] int speedMultiplierTime = 30;
    int distance;
    Text distanceText;
    Text finalScoreText;
    private static GameManager _instance;
    public static GameManager Instance{ get { return _instance; } }

    private void Awake() 
    {
        GameManagerSingleton();    
    }

    // Method to create game manager singleton
    void GameManagerSingleton()
    {
        // if Game Manager instance already exist
        if (_instance != null && _instance != this)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            return;
        }

        // else don't destroy on load
        _instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        finalScoreText = EndMenu.transform.GetChild(1).gameObject.GetComponent<Text>();
        distanceText = GameMenu.transform.GetChild(0).gameObject.GetComponent<Text>();
        ActiveStartMenu();
    }

    void ActiveStartMenu()
    {
        Time.timeScale = 0f;
        StartMenu.SetActive(true);
        GameMenu.SetActive(false);
        EndMenu.SetActive(false);
    }

    public void EndGame()
    {
        finalScoreText.text = "Score : " + distance.ToString();
        Time.timeScale = 0f;
        StartMenu.SetActive(false);
        GameMenu.SetActive(false);
        EndMenu.SetActive(true);
    }

    void Update()
    {
        ProcessScore();
        print("Speed: " + FindObjectOfType<PathManager>().ScrollSpeed);
    }

    void ProcessScore()
    {
        distance = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        distanceText.text = "Meters: " + distance.ToString();
        ProcessGameSpeed(distance);
    }

    void ProcessGameSpeed(int distance)
    {
        //print("distance % speedMultiplierTime: " + distance % speedMultiplierTime);
        if (distance != 0 && distance % speedMultiplierTime == 0)
        {
            //print("Speed increased!");
            FindObjectOfType<PathManager>().ScrollSpeed += Random.Range(0.3f,0.6f) * Time.deltaTime;
        }
    }

    // Method to start game
    public void LoadGame()
    {
        Time.timeScale = 1f;
        ActiveGameMenu();
    }

    void ActiveGameMenu()
    {
        StartMenu.SetActive(false);
        GameMenu.SetActive(true);
        EndMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Quit Application
    public void Quit()
    {
        Application.Quit();
    }
}
