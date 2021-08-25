using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shooting
{
public class SceneManager : MonoBehaviour
{

    public Text GameOverText;

    public Text ScoreText;
    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        ScoreText.text = currentScore.ToString();
    }

    public void ShowGameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        ScoreText.text = currentScore.ToString();
    }
}
}
