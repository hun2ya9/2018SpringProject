using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float forcetoAdd = 100;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody2D>().AddForce(-Vector2.right * forcetoAdd);
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forcetoAdd);
	}
}
