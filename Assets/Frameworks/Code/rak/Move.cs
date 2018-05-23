using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float h = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;        
        transform.position = new Vector3(transform.position.x + h, transform.position.y, 0);
    }
}
