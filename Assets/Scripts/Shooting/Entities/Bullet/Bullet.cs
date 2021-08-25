using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
{

    [Range(0, 10)]
    public float DeadSecond = 3f;
    [Range(0, 200)]
    public float Speed = 100f;

    public Plane plane;

    private bool isOriginal;


    private float time = 0f;

    public void Start()
    {     
        isOriginal = this.gameObject == GameObject.Find("Bullet");



        this.GetComponent<Rigidbody>().AddForce(
            plane.gameObject.transform.forward * Speed,
            ForceMode.VelocityChange
        );
    }
 
    public void Update()
    {
        
        time += Time.deltaTime;

       this.GetComponent<Rigidbody>().transform.Rotate(
            new Vector3(
                0f,
                0.01f,
                0f
            )
        );


        if(!isOriginal && time > DeadSecond){
            Object.Destroy(gameObject);
        }
     }
}
}

