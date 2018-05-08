using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float forceToAdd;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        if (Input.acceleration.x < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forceToAdd);
        }
        //if (Input.GetKey(KeyCode.D))
        if (Input.acceleration.x >0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceToAdd);
        }

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

    }
}
