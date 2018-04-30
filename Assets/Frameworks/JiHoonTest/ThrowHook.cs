using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{

    public GameObject hook;

    public bool ropeActive;
    GameObject curHook;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ropeActive == false)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                curHook = Instantiate(hook, transform.position, Quaternion.identity) as GameObject;

                curHook.GetComponent<Rope>().destiny = destiny;

                ropeActive = true;
            }
            else
            {
                Destroy(curHook);
                ropeActive = false;
            }
        }
    }
}
