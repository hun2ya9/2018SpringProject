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

    public float forceToAdd;
    EndMapCheckerX endMapCheckerX = new EndMapCheckerX();
    EndMapCheckerY endMapCheckerY = new EndMapCheckerY();

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        //if (Input.acceleration.x < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forceToAdd);
        }
        if (Input.GetKey(KeyCode.D))
        //if (Input.acceleration.x > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToAdd);
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
        if (col.CompareTag("Enemy"))
        {
            print("적과의 충돌");
            GameManager.OnHitEffect();
        }
        if (col.CompareTag("Fever"))
        {
            print("FEVER");
            col.gameObject.SetActive(false);
            GameManager.instance.FeverCheck(col);
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
}
