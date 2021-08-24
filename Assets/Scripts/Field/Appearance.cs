using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{

    [SerializeField] GameObject[] enemys;

    [SerializeField] float appearNextTime;

    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;

        if(elapsedTime > appearNextTime){
            elapsedTime = 0f;

            AppearEnemy();
        }
    }

    void AppearEnemy(){
        var randomValue = Random.Range(0, enemys.Length);

        var vector = transform.position + new Vector3(
            Random.value * 5f,
            Random.value * 5f,
            Random.value * 5f
        );

        var randomRotationX = Random.value * 360f;
        var randomRotationY = Random.value * 360f;
        var randomRotationZ = Random.value * 360f;

        GameObject.Instantiate (
            enemys[randomValue],
            vector,
            Quaternion.Euler (randomRotationX, randomRotationY, randomRotationZ)
        );
 
	    elapsedTime = 0f;
    }
}
