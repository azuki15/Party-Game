using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text GameOverText;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowGameOver()
    {
        GameOverText.gameObject.SetActive(true);
        score.GameOver();
    }
}
