using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerData
{
    public string id;
    public string contentId;


}

public class PlayerStateTable : SingletonScriptableObject<PlayerStateTable>
{

#if UNITY_EDITOR
    [MenuItem("Table/PlayerState")]
    private static void Select()
    {
        Selection.activeObject = instance;
    }
#endif

    [TableList]
    [SerializeField] List<PlayerData> playerDatas;

    public static List<string> GetIds()
    {
        return instance.playerDatas.Select(b => b.id).ToList();
    }

    public static PlayerData GetData(string id)
    {
        foreach (var data in instance.playerDatas)
            if (data.id == id)
                return data;
        throw new System.Exception("Can't Find " + id);
    }
}
