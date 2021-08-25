using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
public class Player : MonoBehaviour
{

    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(
            transform.forward * speed,
            ForceMode.VelocityChange
        );
    }

    // Update is called once per frame
    void Update()
    {
        // this.GetComponent<Rigidbody>().transform.Rotate(
        //     new Vector3(
        //         0f,
        //         0.01f,
        //         0f
        //     )
        // );

        this.GetComponent<Rigidbody>().transform.RotateAround(
            Vector3.zero,
            Vector3.up,
            -0.002f
        );
    }

}

}
