using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avoiding
{
    public class CameraController : MonoBehaviour
    {

        public GameObject camera;
        public GameObject player;
        public float rotateSpeed = 2.0f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 angle = new Vector3(
                Input.GetAxis("Mouse X") * rotateSpeed,
                Input.GetAxis("Mouse Y") * rotateSpeed,
                0
            );

            camera.transform.RotateAround(
                player.transform.position,
                Vector3.up,
                angle.x
            );

            camera.transform.RotateAround(
                player.transform.position,
                transform.right,
                angle.y
            );
        }
    }
}
