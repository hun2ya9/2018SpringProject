using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
using System.Collections;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject dropCoinPrefab;
    public Transform coinSpawnContainer;
    public Text coinUIsprite;
    public int feverCoinDropCount;

    public List<Transform> coinSpawnPosition = new List<Transform>();
    public List<GameObject> coinObject = new List<GameObject>();

    // 코인과 충돌시 호출되도록
    public static Action OnCollideCoin;

    private void Awake()
    {
        CreateCoin();
        Fever.OnFeverEffect += FeverCoinDropEffect;
        OnCollideCoin += GetCoin;
        OnCollideCoin += () => AudioManager.instance.PlaySingleEffect(GameManager.instance.coinSound);
    }
    private void Start()
    {
        this.coinUIsprite.text = GameManager.instance.money.ToString();
    }

    private void CreateCoin()
    {
        IListExtensions.Shuffle(coinSpawnPosition);
        for (int i = 0; i < coinSpawnPosition.Count; i++)
        {
            var coinObject = Instantiate(coinPrefab, coinSpawnPosition[i].position, Quaternion.identity, coinSpawnContainer);
            this.coinObject.Add(coinObject);
        }
    }

    // 플레이어가 피버 충돌시 호출할 생각
    public void FeverCoinDropEffect()
    {
        StartCoroutine(CoinDrop());
    }

    private IEnumerator CoinDrop()
    {
        var count = feverCoinDropCount;
        var dropPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        while (count > 0)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0,0.4f));
            var dropCoin = Instantiate(dropCoinPrefab, dropPos + UnityEngine.Random.Range(-3, 3) * Vector3.right, Quaternion.identity, null);
            Destroy(dropCoin, 10);
            count--;
        }
    }

    public void GetCoin()
    {
        GameManager.instance.money += 1;
        this.coinUIsprite.text = GameManager.instance.money.ToString();
    }
}