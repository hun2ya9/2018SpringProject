using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwhook : MonoBehaviour
{
    [Header("Hook")]
    public GameObject hook;
    public bool ropeActive;
    private GameObject curHook;

    [Range(0, 2)]
    public float ropeBlockTime;
    private bool isBlockedRope;

    // 로프 취소
    public static Action RopeCancle;
    public AnimationController ani;

    private void Start()
    {
        RopeCancle += CancelRope;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            if (ropeActive == false && !isBlockedRope)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                curHook = Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeScript>().destiny = destiny;

                ropeActive = true;
                AnimationController.swingAni();
            }
            else
            {
                Destroy(curHook);
                ani.StateReset();
                ropeActive = false;
            }
        }
    }

    // 로프가 지형이 아닌곳에 던져진 경우 바로 지워지도록
    public void CancelRope()
    {
        isBlockedRope = true;
        Invoke("UnBlockRope", ropeBlockTime);
        if (curHook != null)
        {
            Destroy(curHook);
        }
        ropeActive = false;
    }
    private void UnBlockRope()
    {
        isBlockedRope = false;
    }
}
