using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{

    public float moveSpeed = 0.02f;

    public float initialLife = 100;
    public float Life = 100;

    public float interval = 1f;
    private float time = 0f;

    public Image LifeGage;

    public Bullet BulletPrefab;

    public SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        this.GetComponent<Rigidbody>().transform.Translate(
            Input.GetAxisRaw("Horizontal") * moveSpeed,
            Input.GetAxisRaw("Vertical") * moveSpeed,
            0
        );
        


        if (Input.GetButtonDown("Jump")) {
            ShotBullet(transform.position);
            sceneManager.AddScore(-30);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Life -= 10;
            LifeGage.fillAmount = Life / initialLife;

            other.gameObject.SetActive(false);
            Object.Destroy(other.gameObject);

            if(Life <= 0)
            {
                Camera.main.transform.SetParent(null);
                gameObject.SetActive(false);
                // var sceneManager = Object.FindObjectOfType<SceneManager>();
                sceneManager.ShowGameOver();
            }
        }
    }

    // private void OnMouseUpAsButton()
    // {
    //     ShotBullet(transform.position);
    // }

    public void ShotBullet(Vector3 targetPos){

        Object.Instantiate(BulletPrefab, transform.position, Quaternion.identity);

    }
}
