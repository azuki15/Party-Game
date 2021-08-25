using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
public class Appearance : MonoBehaviour
{

    [SerializeField] GameObject[] enemys;

    [SerializeField] float appearNextTime;

    private float elapsedTime;

    public float range = 100;

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
            Random.value * range,
            Random.value * range,
            Random.value * range
        );

        var randomRotationX = Random.value * 360f;
        var randomRotationY = Random.value * 360f;
        var randomRotationZ = 0;

        GameObject.Instantiate (
            enemys[randomValue],
            vector,
            Quaternion.Euler (randomRotationX, randomRotationY, randomRotationZ)
        );
 
	    elapsedTime = 0f;
    }
}

}
