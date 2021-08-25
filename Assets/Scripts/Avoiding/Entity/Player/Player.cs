using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Avoiding
{
    public class Player : MonoBehaviour
    {
        public float speed = 20f;

        public GameOver GameOverText;

        private Rigidbody rb;

        private Vector3 direction;

        // Start is called before the first frame update
        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            direction = new Vector3(0, 0, 0);
        }

        void Update()
        {

            var Horizontal = Input.GetAxis("Horizontal");
            var Vertical = Input.GetAxis("Vertical");



            direction = new Vector3(
                    Horizontal * speed,
                    0,
                    Vertical * speed
                );


            float radious;



            if(Horizontal == 1)
            {
                if(Vertical == 1)
                {
                    radious = 315f;
                }
                else if(Vertical == 0 )
                {
                    radious = 0f;
                }
                else
                {
                    radious = 45f;
                }
            }
            else if(Horizontal == 0)
            {
                if(Vertical == 1)
                {
                    radious = 270f;
                }
                else if(Vertical == 0 )
                {
                    radious = 0f;
                }
                else
                {
                    radious = 90f;

                }
            }
            else
            {
                if(Vertical == 1)
                {
                    radious = 215f;
                }
                else if(Vertical == 0 )
                {
                    radious = 180f;
                }
                else
                {
                    radious = 135f;

                }
            }

            if(Horizontal != 0 || Vertical != 0)
            {
                rb.transform.rotation = Quaternion.Euler(
                        0,
                        radious,
                        0
                );
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.velocity = direction;
        }


        void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.tag == "Enemy")
            {
                this.gameObject.SetActive(false);
                GameOverText.ShowGameOver();
            }
        }
    }
    
}