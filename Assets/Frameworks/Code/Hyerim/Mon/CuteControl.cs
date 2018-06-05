using UnityEngine;
using System.Collections;

public class CuteControl : MonoBehaviour
{
    public CuteAniController ani;
    public float movePower = 1f;
    private Vector2 startPos;
    public int distance;
    public int moveSpeed;
    public SpriteRenderer render;
    private bool isFlip = false;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var xForce = (transform.position.x + moveSpeed) * Time.deltaTime;
        if (!isFlip)
            xForce = -xForce;
        transform.Translate(new Vector3(xForce, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("MovingLimit"))
        {
            isFlip = isFlip == true ? false : true;
            render.flipX = isFlip;
        }
    }
}
