using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //それぞれのチェックポイントの座標を取得
    public Transform[] RoutePoints;


    //0~200の間でスピードを指定
    [Range(0, 200)]
    public float Speed = 10f;

    //0~50の範囲で
    [Range(0, 50)]
    //横に動く速度を指定
    public float MoveSpeed = 10f;
    //横に動ける範囲を指定
    public float MoveRange = 40f;

    public float _initialLife = 100;
     public float Life = 100;
    public Image LifeGage;

        public Bullet BulletPrefab;

    //チェックポイントまで到達したか
    bool _isHitRoutePoint;


    IEnumerator Move()
    {
        //スタート地点の座標
        var prevPointPos = transform.position;
        var basePosition = transform.position;

        //初速？
        var movedPos = Vector2.zero;

        foreach (var nextPoint in RoutePoints)
        {

            //falseに設定
            _isHitRoutePoint = false;

            //チェックポイントに当たるまではループを回る
            while(!_isHitRoutePoint)
            {
                //次のチェックポイントと前のチェックポイント（or スタート地点）のベクトルを取得
                var vec = nextPoint.position - prevPointPos;
                vec.Normalize();

                // プレイヤーを次のチェックポイントへと進めるベクトル
                basePosition += vec * Speed * Time.deltaTime;

                //上下左右に移動する処理
                // 行列によるベクトルの変換に関係する知識を利用しています。

                //水平方向に与えるベクトル（力）を取得
                movedPos.x += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

                //垂直方向に与えるベクトル（力）を取得
                movedPos.y += Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

                movedPos = Vector2.ClampMagnitude(movedPos, MoveRange);
                var worldMovedPos = Matrix4x4.Rotate(transform.rotation).MultiplyVector(movedPos);
 
                //ルート上の位置に進む力と上下左右にいった結果を代入
                transform.position = basePosition + worldMovedPos;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vec, Vector3.up), 0.5f);
 
                //1フレーム分の処理を終了
                yield return null;
            }

            //チェックポイントについたら、今まで目指していたチェックポイントを、前のチェックポイントとして扱う
            prevPointPos = nextPoint.position;       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //チェックポイントに当たれば
        if(other.gameObject.tag == "RoutePoint")
        {
            other.gameObject.SetActive(false);
            _isHitRoutePoint = true;
        }
        //敵に当たれば
        else if(other.gameObject.tag == "Enemy")
        {
            Life -= 10f;
            LifeGage.fillAmount = Life / _initialLife;

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

    public void ShotBullet(Vector3 targetPos)
    {
        var bullet = Object.Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(transform.position, targetPos);
    }

    void Start()
    {
        StartCoroutine(Move());
    }

}
