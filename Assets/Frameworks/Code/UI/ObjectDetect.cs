using UnityEngine;
using System.Collections;

public class ObjectDetect : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            transform.position = player.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Detect"))
        {
            col.transform.parent.GetChild(0).gameObject.SetActive(true);
            //for (int i = 0; i < col.transform.childCount; i++)
            //{
            //    col.transform.GetChild(i).gameObject.SetActive(true);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Detect"))
        {
            col.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    }
}
