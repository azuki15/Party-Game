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
            direction = new Vector3(
                    Input.GetAxis("Horizontal") * speed,
                    0,
                    Input.GetAxis("Vertical") * speed
                );
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