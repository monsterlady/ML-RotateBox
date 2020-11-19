using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHistory : MonoBehaviour
{

    private int highscore = 0;

    public Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = "HighScore: " + Highscore;
    }

    public int Highscore
    {
        get => highscore;
        set => highscore = value;
    }
}
