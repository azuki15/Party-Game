using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    public int scorePerSeconds = 100;

    private int currentScore = 0;
    private float time = 0f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!isGameOver && time >= 1){
            time = 0f;
            currentScore += scorePerSeconds;
            ScoreText.text = currentScore.ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
