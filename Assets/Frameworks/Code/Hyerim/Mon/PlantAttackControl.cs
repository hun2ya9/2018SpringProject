using UnityEngine;
using System.Collections;

public class PlantAttackControl : MonoBehaviour
{
    public Animator ani;
    public Animator ballAni;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            ani.SetBool("isAttack", true);
            ballAni.SetBool("isShot",transform);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ani.SetBool("isAttack", false);
            ballAni.SetBool("isShot",false);
        }
    }
}