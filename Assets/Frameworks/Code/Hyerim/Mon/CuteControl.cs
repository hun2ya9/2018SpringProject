using UnityEngine;
using System.Collections;

public class CuteControl : MonoBehaviour
{
    public CuteAniController ani;
    public float movePower;
    public int distance;
    public int moveSpeed;
    public SpriteRenderer render;
    private bool isFlip = false;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var xForce = moveSpeed * Time.deltaTime;
        if (!isFlip)
            xForce = -xForce;
        transform.Translate(new Vector3(xForce, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("MovingLimit"))
        {
            isFlip = isFlip == true ? false : true;
            render.flipX = !isFlip;
        }
    }
}
