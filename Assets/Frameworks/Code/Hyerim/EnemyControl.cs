using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public EnemyAniController ani;
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
        var tempDis = Vector2.Distance(startPos, transform.position);
        print(tempDis);
        if (tempDis > distance)
        {
            moveSpeed = -moveSpeed;
            isFlip = isFlip == true ? false : true;
            render.flipX = isFlip;
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        transform.position = new Vector3((transform.position.x + moveSpeed) * Time.deltaTime, transform.position.y, 0);
    }
}
