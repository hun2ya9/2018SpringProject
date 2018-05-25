using UnityEngine;
using System.Collections;
using System;

public class GetItemEffect : MonoBehaviour
{
    public Transform playerPosition;
    public ParticleSystem getItemParticle;
    public static Action OnItemEffect;

    private void Awake()
    {
        OnItemEffect += ItemEffect;
    }
    private void ItemEffect()
    {
        getItemParticle.transform.position = playerPosition.position;
        getItemParticle.Play();
    }


}
