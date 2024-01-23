using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;

    public GameObject unitychan;

    public GameObject generationrange;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 370;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private float itemInterval = 15;

    private float unitychanDistance;

    private int generateFunctionCallCount = 0;

    private float generationpoint;





    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");

        generationrange = GameObject.Find("generationrange");

        generationpoint = unitychan.transform.position.z + 15;

        
    }


    // Update is called once per frame
    void Update()
    {
        unitychan = GameObject.Find("unitychan");

        generationrange = GameObject.Find("generationrange");

        itemgenerate();

           
        
       
        


    }

    void itemgenerate()
    {
        generateFunctionCallCount++;

        if (generationpoint<generationrange.transform.position.z&&generationpoint<goalPos)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generationpoint);

                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generationpoint + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, generationpoint + offsetZ);
                    }
                }
            }

            generationpoint += 15;
        }

       

        Debug.Log("GenerateItems function call count: " + generateFunctionCallCount);

        }
}