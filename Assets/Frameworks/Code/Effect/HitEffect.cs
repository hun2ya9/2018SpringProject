using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine.PostProcessing;
using System;

public class HitEffect : MonoBehaviour
{
    [Header("Special Effect")]
    private PostProcessingBehaviour postProcessing;
    private VignetteModel vignette;
    public float hitEffectTime;

    public static Action OnHitEffect;

    private void Start()
    {
        postProcessing = Camera.main.GetComponent<PostProcessingBehaviour>();
        vignette = postProcessing.profile.vignette;
        vignette.enabled = false;
        OnHitEffect = OnEffect;
    }

    public void OnEffect()
    {
        print("피격당함");
        vignette.enabled = true;
        Invoke("HitEffectInvoke", hitEffectTime);
    }

    private void HitEffectInvoke()
    {
        vignette.enabled = false;
        Throwhook.RopeCancle();
    }
}
