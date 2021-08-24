using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Range(0, 10)]
    public float DeadSecond = 3f;
    [Range(0, 200)]
    public float Speed = 100f;
 
    public Vector3 StartPos { get; set; }
    public Vector3 TargetPos { get; set; }

    private bool isOriginal;


    private float time = 0f;

    public void Start()
    {
        isOriginal = this.gameObject == GameObject.Find("Bullet");
        this.GetComponent<Rigidbody>().AddForce(
            transform.forward * Speed,
            ForceMode.VelocityChange
        );
    }
 
    public void Update()
    {
        
        time += Time.deltaTime;

        if(!isOriginal && time > DeadSecond){
            Object.Destroy(gameObject);
        }
     }
}
