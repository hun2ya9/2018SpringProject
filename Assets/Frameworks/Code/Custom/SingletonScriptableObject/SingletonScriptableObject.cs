using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*
#if UNITY_EDITOR
    [MenuItem("DB/EnemyDB")]
    static void Select()
    {
        Selection.activeObject = instance;
    }
#endif
*/

public abstract class SingletonScriptableObject<TSelf> : SerializedScriptableObject where TSelf : SerializedScriptableObject
{
    // 첫 로드될 때 실행
    protected virtual void Initialize() { }

    // 매 로드될 때 실행
    protected virtual void Update() { }

    private static string path {
        get { return "Assets/Resources/" + typeof(TSelf).Name + ".asset"; }
    }

    private static TSelf m_insatnce;
    protected static TSelf instance {
        get
        {
            if (m_insatnce == null)
                m_insatnce = Load();

            #if UNITY_EDITOR
            if (m_insatnce == null)
                m_insatnce = CreateNewScriptableObject();
            #endif

            return m_insatnce;
        }
    }

    static TSelf Load()
    {
        Regex regex = new Regex(
            @"Assets/Resources/(?<resourcesPath>.*).asset"
        );
        string resourcesPath = regex.Match(path).Groups["resourcesPath"].Value;
        ScriptableObject scriptableObject = Resources.Load<TSelf>(resourcesPath);
        bool loaded = scriptableObject != null;

        Debug.Log("Load] " + resourcesPath + " : " + (loaded ? "Success" : "Fail"));

        if (loaded)
            ((SingletonScriptableObject<TSelf>)scriptableObject).Update();
        return scriptableObject as TSelf;
    }

#if UNITY_EDITOR
    static TSelf CreateNewScriptableObject()
    {
        TSelf scriptableObject = CreateInstance<TSelf>();
        if (!AssetDatabase.IsValidFolder("Assets/Resources"))
        {
            Debug.Log("Create] Resources Folder");
            AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.Refresh();
        }

        Debug.Log("Create] " + path);
        AssetDatabase.CreateAsset(scriptableObject, path);
        AssetDatabase.ImportAsset(path);

        (scriptableObject as SingletonScriptableObject<TSelf>).Initialize();

        return scriptableObject;
    }
#endif
    
#if UNITY_EDITOR
    public static void Save()
    {
        EditorUtility.SetDirty(instance);
        AssetDatabase.SaveAssets();
    }
#endif

}
