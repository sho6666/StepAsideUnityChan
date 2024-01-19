using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;

    private GameObject Car;

    private GameObject Coin;

    private GameObject TrafficCone;

    void OnBecameInvisible()
    {
        Destroy(Coin);
        Destroy(Car);
        Destroy(TrafficCone);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        //障害物のオブジェクトを取得//
        this.Car = GameObject.Find("CarPrefab");
        this.Coin = GameObject.Find("CoinPrefab");
        this.TrafficCone = GameObject.Find("TrafficConePrefab");
    }

    // Update is called once per frame
    void Update()
    {

        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);



    }
}
