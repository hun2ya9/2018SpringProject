using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;

public class Fever : MonoBehaviour
{
    public Transform feverSpawnContainer;
    public List<Transform> feverSpawnPosition = new List<Transform>();
    public List<GameObject> feverPrefab = new List<GameObject>();
    public List<GameObject> feverObject = new List<GameObject>();
    public List<Image> feverUIsprite = new List<Image>();
    public bool[] hasFever;
    private int totalGetFeverCount;
   
    public Text[] FeverText = new Text[6];
    public List<Text> FeverShow2 = new List<Text>();
    /*public List<GameObject> CoinObject = new List<GameObject>();
    public List<Transform> CoinDropPosition = new List<Transform>();
    public List<Image> CoinImage = new List<Image>;*/
    
    // 피버 글자와 충돌시 일어나는 효과
    public static Action<Collider2D> OnHitFever;

    // 이 액션은 피버 발생시 일어나는 모든 효과를 담는다.
    public static Action OnFeverEffect;

    private void Awake()
    {
        hasFever = new bool[feverUIsprite.Count];
        CreateFever();
        OnHitFever += FeverCheck;
    }
    private void CreateFever()
    {
        IListExtensions.Shuffle(feverSpawnPosition);
        for (int i = 0; i < feverPrefab.Count; i++)
        {
            var feverObject = Instantiate(feverPrefab[i], feverSpawnPosition[i].position, Quaternion.identity, feverSpawnContainer);
            this.feverObject.Add(feverObject);
        }
    }

    // 플레이어가 피버 충돌시 호출할 생각
    public void FeverCheck(Collider2D col)
    {
        var feverList = feverObject;
        for (int i = 0; i < feverList.Count; i++)
        {
            if (col.gameObject.Equals(feverList[i]))
            {
                hasFever[i] = true;
                totalGetFeverCount++;
                HighAlpha(feverUIsprite[i]);
            }
        }
        if (totalGetFeverCount == hasFever.Length)
        {
            print("FEVER를 다 모았습니다.");
            for (int i = 0; i < FeverText.Length; i++)
            {
                LowAlpha(feverUIsprite[i]);
                /*FeverText[i].SetActive(false);*//*왜 안되는지 모르겠습니다*/
                // 오브젝트를 끄는것 보다는 Image의 투명도를 조절
            }
            OnFeverEffect();
        }
    }

    public void HighAlpha(Image fever)
    {
        fever.color = new Color(1, 1, 1);
    }
    public void LowAlpha(Image fever)
    {
        fever.color = new Color(1, 1, 0.3f);
    }
}