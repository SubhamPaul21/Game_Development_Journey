using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private static ShowScore _instance;

    public static ShowScore Instance
    {
        get
        {
            return _instance;
        }
    }
    public int Score { get; private set; } = 0;

    Text scoreText;

    private void Awake()
    {
        _instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "  Score: " + Score.ToString();
    }

    // Method to update the score of fruit cut
    public void IncrementScore(int value)
    {
        Score += value;
        scoreText.text = "  Score: " + Score.ToString();
    }
}
