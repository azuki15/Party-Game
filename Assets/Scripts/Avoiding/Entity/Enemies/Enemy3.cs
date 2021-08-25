using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avoiding
{
    public class Enemy3 : MonoBehaviour
    {
        public float power = 100f;

        private Rigidbody rb;


            // Start is called before the first frame update
        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            rb.AddForce(
                new Vector3(
                    power * Random.value,
                    power * Random.value,
                    power * Random.value
                )
            );
        }
        // Update is called once per frame
        void Update()
        {
            rb.AddForce(
                new Vector3(
                    0,
                    -15f,
                    0
                )
            );
            rb.transform.Rotate(
                new Vector3(
                    0.1f,
                    0.1f,
                    0
                )
            );
        }
    }
}

