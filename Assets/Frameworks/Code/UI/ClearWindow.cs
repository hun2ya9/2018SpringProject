using UnityEngine;
using System;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    public Text clearTIme;

    private void OnEnable()
    {
        var currentTime = GameManager.instance.playTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        clearTIme.text = string.Format("{0:D2} : {1:D2} : {2:D2}", time.Hours, time.Minutes, time.Seconds);
    }
    private void OnDisable()
    {
        clearTIme.text = string.Empty;
    }
}
