using UnityEngine;
using System.Collections;

public class MonsterDetectControl : MonoBehaviour
{
    public GameObject detectObject;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = detectObject.transform.position;
    }
}
