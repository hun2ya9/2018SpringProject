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
    public List<Image> feverUIsprite= new List<Image>();
    public bool[] hasFever;

    public static Action<Collider2D> OnHitFever;

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
        int totalCount = 0;
        for (int i = 0; i < feverList.Count; i++)
        {
            if (col.gameObject.Equals(feverList[i]))
            {
                hasFever[i] = true;
                totalCount++;
                ChangeAlpha(feverUIsprite[i]);
            }
        }
        if (totalCount == hasFever.Length)
        {
            //모든 fever를 먹었을 때
        }
    }

    public void ChangeAlpha(Image fever)
    {
        fever.color = new Color(1, 1, 1);
    }

}