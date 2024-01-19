using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //Unity�����ƃJ�����̋���
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
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //Unity�����ƃJ�����̈ʒu�iz���W�j�̍������߂�
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        //��Q���̃I�u�W�F�N�g���擾//
        this.Car = GameObject.Find("CarPrefab");
        this.Coin = GameObject.Find("CoinPrefab");
        this.TrafficCone = GameObject.Find("TrafficConePrefab");
    }

    // Update is called once per frame
    void Update()
    {

        //Unity�����̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);



    }
}
