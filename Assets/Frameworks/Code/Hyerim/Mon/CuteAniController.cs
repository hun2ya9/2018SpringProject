using UnityEngine;
using System.Collections;

public class CuteAniController : MonoBehaviour
{
    public Animator playerAni;
    public SpriteRenderer render;
    private bool isFlip;
    
    public void Walk()
    {
        playerAni.SetBool("isAttack", false);
    }

    public void Attack()
    {
        playerAni.SetBool("isAttack", true);
    }
}
