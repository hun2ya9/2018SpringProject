using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System;

public class InvertEffect : MonoBehaviour
{
    public Material invertMaterial;
    [Range(0,1)]
    public float invertValue;

    public static Action<int> OnSlowEffect;
    public static Action<int> OnFastEffect;

    private void Awake()
    {
        invertValue = invertMaterial.GetFloat("_Threshold");
        OnSlowEffect += SlowEffect;
        OnFastEffect += FastEffect;
    }
    private void Update()
    {
        invertMaterial.SetFloat("_Threshold", invertValue);
    }

    public void SlowEffect(int invertTime)
    {
        invertValue = 1;
        Invoke("Reest", invertTime);
    }

    public void FastEffect(int invertTime)
    {
        invertValue = 0.5f;
        Invoke("Reest", invertTime);
    }

    private void Reest()
    {
        invertValue = 0;
    }
}
