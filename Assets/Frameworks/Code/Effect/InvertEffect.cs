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

    private void Start()
    {
        invertValue = invertMaterial.GetFloat("_Threshold");
        // 항상 어떻게 되든 inverValue는 0으로 시작하게끔 (100%가 아닌 임시적인 해결책일 뿐임)
        invertValue = 0;
        OnSlowEffect = SlowEffect;
        OnFastEffect = FastEffect;
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
