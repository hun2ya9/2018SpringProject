using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
using System;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class ItemData
{
    public string id;
    public int runTime;
    public Action<int> ItemAction;
}

public class ItemTable : SingletonScriptableObject<ItemTable>
{

#if UNITY_EDITOR
    [MenuItem("Table/Item")]
    private static void Select()
    {
        Selection.activeObject = instance;
    }
#endif

    [TableList]
    [SerializeField]
    List<ItemData> itemDatas;

    public static List<string> GetIds()
    {
        return instance.itemDatas.Select(b => b.id).ToList();
    }

    public static ItemData GetData(string id)
    {
        foreach (var data in instance.itemDatas)
            if (data.id == id)
                return data;
        throw new System.Exception("Can't Find " + id);
    }
}


