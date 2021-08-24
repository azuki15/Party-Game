using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public float moveSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        // this.GetComponent<Rigidbody>().AddForce(
        //     transform.forward * speed,
        //     ForceMode.VelocityChange
        // );
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().transform.Translate(
            Input.GetAxisRaw("Horizontal") * moveSpeed,
            Input.GetAxisRaw("Vertical") * moveSpeed,
            0
        );
        // this.GetComponent<Rigidbody>().AddForce(
        //     transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed,
        //     ForceMode.Impulse
        // );
    }
}
