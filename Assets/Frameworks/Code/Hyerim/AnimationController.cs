using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System;

public class AnimationController : MonoBehaviour
{
    public Animator playerAni;
    public SpriteRenderer render;
    private bool isFlip;
    public static Action swingAni;

    void Start()
    {
        swingAni = Swing;
    }

    [Button(name : "Reset")]
    public void StateReset()
    {
        playerAni.SetBool("isMove", false);
        playerAni.SetBool("isSwing", false);
    }
    [Button(name : "LeftMove")]
    public void LeftMove()
    {
        if (!playerAni.GetBool("isSwing"))
        {
            playerAni.SetBool("isMove", true);
            if (isFlip)
            {
                isFlip = false;
                render.flipX = isFlip;
            }
        }
    }
    [Button(name: "RightMove")]
    public void RightMove()
    {
        if (!playerAni.GetBool("isSwing"))
        {
            playerAni.SetBool("isMove", true);
            if (!isFlip)
            {
                isFlip = true;
                render.flipX = isFlip;
            }
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
    public void MovePause()
    {
        if (!playerAni.GetBool("isSwing"))
        {
            playerAni.SetBool("isMove", false);
            playerAni.SetBool("isSwing", false);
        }
    }
}
