using UnityEngine;
using System.Collections.Generic;

public class FeverSpawn : MonoBehaviour
{
    public Transform feverSpawnContainer;
    public List<Transform> feverSpawnPosition = new List<Transform>();
    public List<GameObject> feverPrefab = new List<GameObject>();

    private void Awake()
    {
        CreateFever();
    }

    private void CreateFever()
    {
        IListExtensions.Shuffle(feverSpawnPosition);
        for (int i = 0; i < feverPrefab.Count; i++)
        {
           var feverObject = Instantiate(feverPrefab[i], feverSpawnPosition[i].position, Quaternion.identity, feverSpawnContainer);
            GameManager.instance.feverObject.Add(feverObject);
        }
    }
}