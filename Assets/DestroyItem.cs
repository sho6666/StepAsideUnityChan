using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour

{
    private GameObject MainCamera;

    private float difference;

    private GameObject Car;

    private GameObject Coin;

    private GameObject TrafficCone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.MainCamera = GameObject.Find("MainCamera");

        this.Car = GameObject.Find("CarPrefab(Clone)");

        this.Coin = GameObject.Find("CoinPrefab(Clone)");

        this.TrafficCone = GameObject.Find("TrafficConePrefab(Clone)");

    }

    private void OnBecameInvisible()
    {
        Destroy(this.Car);
        Destroy(this.Coin);
        Destroy(this.TrafficCone);

    }
}
