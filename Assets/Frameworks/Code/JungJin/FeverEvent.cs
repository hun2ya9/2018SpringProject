using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverEvent : MonoBehaviour
{
    public GameObject Coin;
    public int CoinNumber;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CoinDrop()
    {
        for (int i = 0; i < CoinNumber; i++)
        {
            Coin.transform.position = Camera.main.transform.position + UnityEngine.Random.Range(-3, 3) * Vector3.right;
            Instantiate(Coin, Coin.transform.position, Quaternion.identity);

        }

        Destroy(Coin, 1);

    }

}
