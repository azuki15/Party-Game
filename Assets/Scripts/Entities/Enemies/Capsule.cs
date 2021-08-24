using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [Range(0, 100)]
    public float Speed = 10;
    public float DeadSecond = 10f;

    private float time;
    private Plane plane;
    private bool isOriginal;

    public float Life = 10;

    public SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        plane = Object.FindObjectOfType<Plane>();
        isOriginal = this.gameObject == GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {

        // if(Input.GetMouseButton(0)){
        //     plane.ShotBullet(transform.position);
        // }

        time += Time.deltaTime;
        if(!isOriginal && time >= DeadSecond)
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            // var vector = plane.transform.position - transform.position;
            // transform.position += vector.normalized * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Life -= 10;
            Object.Destroy(other.gameObject);

            if(Life <= 0)
            {
                Object.Destroy(gameObject);
                // var sceneManager = Object.FindObjectOfType<SceneManager>();
                sceneManager.AddScore(100);
            }
        }
    }

    // private void OnMouseUpAsButton()
    // {
    //     plane.ShotBullet(transform.position);
    // }
}
