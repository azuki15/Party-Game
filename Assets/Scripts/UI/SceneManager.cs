using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }
}