using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //conePrefab������
    public GameObject conePrefab;

    public GameObject unitychan;

    public GameObject generationrange;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 370;
    //�A�C�e�����o��x�����͈̔�
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
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generationpoint);

                }
            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generationpoint + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
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