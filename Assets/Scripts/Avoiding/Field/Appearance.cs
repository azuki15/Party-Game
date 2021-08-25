using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avoiding
{
    public class Appearance : MonoBehaviour
    {

        public GameObject[] enemies;

        public int maxNum = 1;

        private int num = 0;

        public float appearNextTime;

        private float elapsedTime;
        
        // Start is called before the first frame update
        void Start()
        {
            elapsedTime = appearNextTime;
        }

        // Update is called once per frame
        void Update()
        {
            elapsedTime += Time.deltaTime;

            if(
                num < maxNum &&
                elapsedTime > appearNextTime
                )
            {
                elapsedTime = 0f;

                AppearEnemy();

                num++;
            }
        }

        void AppearEnemy()
        {
            var randomValue = Random.Range(0, enemies.Length);

            var randomRotationX = Random.value * 360f;
            var randomRotationY = Random.value * 360f;
            var randomRotationZ = Random.value * 360f;

            GameObject.Instantiate(
                enemies[randomValue],
                this.transform.position,
                Quaternion.Euler (randomRotationX, randomRotationY, randomRotationZ)
            );
        }
    }

}
