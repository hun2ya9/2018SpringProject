using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject ExitPortal;

    void Start()
    {
        if(ExitPortal==null)
        {
            gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject visitor = col.gameObject;

                StartCoroutine(TelePort(visitor));
            }
        }
    }

    IEnumerator TelePort(GameObject targetObject)
    {
        yield return new WaitForSeconds(1);
        targetObject.transform.position = new Vector2(ExitPortal.transform.position.x, ExitPortal.transform.position.y);
    }
}
