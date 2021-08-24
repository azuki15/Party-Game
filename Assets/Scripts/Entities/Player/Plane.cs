using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{

    public float moveSpeed = 0.02f;

    public float initialLife = 100;
    public float Life = 100;
    public Image LifeGage;

    public Bullet BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().transform.Translate(
            Input.GetAxisRaw("Horizontal") * moveSpeed,
            Input.GetAxisRaw("Vertical") * moveSpeed,
            0
        );
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
                var sceneManager = Object.FindObjectOfType<SceneManager>();
                sceneManager.ShowGameOver();
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        ShotBullet(transform.position);
    }

    public void ShotBullet(Vector3 targetPos){

        var bullet = Object.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(transform.position, targetPos);
    }
}
