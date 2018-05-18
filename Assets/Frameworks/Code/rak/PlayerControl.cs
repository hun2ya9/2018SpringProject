using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float forceToAdd;
    

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
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
    // 충돌 제어
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            print(col.name);
            var data = ItemTable.GetData(col.name);
            if (data != null)
            {
                data.ItemAction(data.runTime);
            }
        }
    }
}
