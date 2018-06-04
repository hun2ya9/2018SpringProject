using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : MonoBehaviour
{
    private class EndMapCheckerX
    {
        public bool BIsEndOfMapX { set; get; }
    }

    private class EndMapCheckerY
    {
        public bool BlsEndOfMapY { set; get; }
    }

    EndMapCheckerX endMapCheckerX = new EndMapCheckerX();
    EndMapCheckerY endMapCheckerY = new EndMapCheckerY();

    private Rigidbody2D rigidBody;

    [Header("Value")]
    public float forceToAdd;
    public int hitForce;
    [Space]
    public AnimationController ani;

    public static Action<int> Big;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        Big += BigItemEffect;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        //if (Input.acceleration.x < 0)
        {
            
            GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forceToAdd);
            ani.LeftMove();
        }
        if (Input.GetKey(KeyCode.D))
        //if (Input.acceleration.x > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToAdd);
            ani.RightMove();
        }
        if (rigidBody.velocity == Vector2.zero)
        {
            ani.MovePause();
        }

        CameraControl();
    }

    // 카메라 제어
    private void CameraControl()
    {
        if (endMapCheckerY.BlsEndOfMapY == false && endMapCheckerX.BIsEndOfMapX == false)
        {
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
        else if (endMapCheckerY.BlsEndOfMapY == true || endMapCheckerX.BIsEndOfMapX == true)
        {
            if(endMapCheckerY.BlsEndOfMapY == true && endMapCheckerX.BIsEndOfMapX == true)
            {
                Camera.main.transform.position = new Vector3(
                                                    Camera.main.transform.position.x, 
                                                    Camera.main.transform.position.y, 
                                                    Camera.main.transform.position.z);
            }
            else if (endMapCheckerY.BlsEndOfMapY == true)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
            else
                Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            print("적과의 충돌");
            var vector = transform.position - col.transform.position;
            rigidBody.AddForce(vector * hitForce);
            HitEffect.OnHitEffect();
            ani.Hit();
        }
    }

    // 트리거 제어
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            print("코인 획득");
            col.gameObject.SetActive(false);
            /*var data*/
        }
        if (col.CompareTag("Item"))
        {
            print("아이템 획득");
            var data = ItemTable.GetData(col.name);
            if (data != null)
            {
                col.gameObject.SetActive(false);
                data.ItemAction(data.runTime);
                GetItemEffect.OnItemEffect();
            }
        }
        if (col.CompareTag("Fever"))
        {
            print("FEVER");
            col.gameObject.SetActive(false);
            Fever.OnHitFever(col);
        }
        
        if(col.CompareTag("EndMapX"))
        {
            endMapCheckerX.BIsEndOfMapX = true;
        }

        if (col.CompareTag("EndMapY"))
        {
            endMapCheckerY.BlsEndOfMapY = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("EndMapX"))
        {
            endMapCheckerX.BIsEndOfMapX = false;
        }

        if (col.CompareTag("EndMapY"))
        {
            endMapCheckerY.BlsEndOfMapY = false;
        }
    }

    private void BigItemEffect(int runTime)
    {
        transform.localScale *= 2;
        Invoke("ResetBig", runTime);
    }

    private void ResetBig()
    {
        transform.localScale /= 2;
    }
}
