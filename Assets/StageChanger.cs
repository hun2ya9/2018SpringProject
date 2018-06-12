using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    public GameObject stageTextObject;
    public GameObject clearWindow;

    // Use this for initialization
    void Start()
    {
        if (stageTextObject == null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stageTextObject.SetActive(true);
            if (clearWindow != null)
            {
                clearWindow.SetActive(true);
            }
        }
    }
}
