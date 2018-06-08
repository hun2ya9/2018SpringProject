using UnityEngine;
using System.Collections;

public class SpikeControl : MonoBehaviour
{
    public bool isTrapOn;
    public float trapDistance;
    private float originPositionY;
    private float limit = 0.3f;
    private void Start()
    {
        originPositionY = transform.position.y;
    }

    private void Update()
    {
        if (isTrapOn && originPositionY + limit > transform.position.y)
        {
            transform.Translate(Vector3.up * trapDistance * Time.deltaTime);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("플레이어가 빠져나감");
            SpikeTrapExit();
        }
    }

    // 트랩 발동
    public void SpikeTrapExecute()
    {
        isTrapOn = true;
    }

    private void SpikeTrapExit()
    {
        isTrapOn = false;
        transform.Translate(Vector3.up * -trapDistance);
    }
}
