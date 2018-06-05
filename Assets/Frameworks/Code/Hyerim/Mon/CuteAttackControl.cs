using UnityEngine;
using System.Collections;

public class CuteAttackControl : MonoBehaviour
{
    public CuteAniController ani;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            print("적이 플레이어를 감지");
            ani.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ani.Walk();
        }
    }
}
