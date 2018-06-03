using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System;

public class AnimationController : MonoBehaviour
{
    public Animator playerAni;
    public SpriteRenderer render;
    private bool isFlip;

    [Button(name : "Reset")]
    public void StateReset()
    {
        playerAni.SetBool("isMove", false);
        playerAni.SetBool("isSwing", false);
    }
    [Button(name : "LeftMove")]
    public void LeftMove()
    {
        playerAni.SetBool("isMove", true);
        if (isFlip)
        {
            isFlip = false;
            render.flipX = isFlip;
        }
    }
    [Button(name: "RightMove")]
    public void RightMove()
    {
        playerAni.SetBool("isMove", true);
        if (!isFlip)
        {
            isFlip = true;
            render.flipX = isFlip;
        }
    }
    [Button(name: "Swing")]
    public void Swing()
    {
        playerAni.SetBool("isSwing", true);
    }
    [Button(name: "Hit")]
    public void Hit()
    {
        playerAni.SetTrigger("Hit");
    }
    [Button(name: "Die")]
    public void Die()
    {
        playerAni.SetTrigger("Die");
    }

}
