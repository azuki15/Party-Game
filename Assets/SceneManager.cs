using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //using文追加

public class SceneManager : MonoBehaviour
{

    //SceneManagerスクリプトに次のものを追加
    // フィールドの追加
    public Text GameOverText;
    //メソッドの追加
    private void Start()
    {
        GameOverText.gameObject.SetActive(false);
    }
    public void ShowGameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
