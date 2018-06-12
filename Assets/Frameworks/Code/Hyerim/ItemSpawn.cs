using UnityEngine;
using System.Collections.Generic;

public class ItemSpawn : MonoBehaviour
{
    public Transform itemSpawnContainer;
    public List<Transform> ItemSpawnPosition = new List<Transform>();
    public List<GameObject> ItemPrefab = new List<GameObject>();

    private void Start()
    {
        CreateItem();
    }

    private void CreateItem()
    {
        foreach (var pos in ItemSpawnPosition)
        {
            GameObject newItem = ItemPrefab[Random.Range(0,ItemPrefab.Count)];
            Instantiate(newItem, pos.transform.position, Quaternion.identity,itemSpawnContainer);
            //pos.gameObject.SetActive(false);
        }
    }
}