using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhiteBirdControl : MonoBehaviour
{
    private bool isFlip = false;
    public SpriteRenderer render;
    public int moveSpeed;
    public float movePower;

    private void Start()
    {
        StartCoroutine(Flip());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var xForce = moveSpeed * Time.deltaTime;
        if (!isFlip)
            xForce = -xForce;
       this.gameObject.transform.Translate(new Vector3(xForce, 0, 0));
    }


    private IEnumerator Flip()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            isFlip = isFlip == true ? false : true;
            render.flipX = isFlip;
        }
    }
}