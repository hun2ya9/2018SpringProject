using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    public Text clearTIme;

    private void OnEnable()
    {
        clearTIme.text = GameManager.instance.playTime.ToString();
    }
    private void OnDisable()
    {
        clearTIme.text = string.Empty;
    }
}
