using UnityEngine;
using System.Collections;
using System;

public class GetItemEffect : MonoBehaviour
{
    public Transform playerPosition;
    public ParticleSystem getItemParticle;
    public static Action OnItemEffect;

    private void Start()
    {
        var player = GameManager.instance.currentPlayer;
        if (player != null)
        {
            playerPosition = GameManager.instance.currentPlayer.transform;
        }
        else
        {
            Debug.Log("플레이어를 찾지 못함");
        }
        OnItemEffect = ItemEffect;
    }
    private void ItemEffect()
    {
        getItemParticle.transform.position = playerPosition.position;
        getItemParticle.Play();
    }


}
