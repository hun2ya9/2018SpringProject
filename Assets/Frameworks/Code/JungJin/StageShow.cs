using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageShow : MonoBehaviour {

    //텍스트를 유지하는 시간
    public float KeepDuration;

    //텍스트를 페이드 아웃하는 시간
    public float FadeDuration;

    //페이드 아웃할 텍스트 객체
    private Text stageText;

    void Start()
    {
        if (FadeDuration <= 0f)
        {
            FadeDuration = 2.0f;
        }
        if (KeepDuration <= 0f)
        {
            KeepDuration = 2.0f;
        }
        stageText = GetComponent<Text>();
        if (stageText == null)
        {
            gameObject.SetActive(false);
        }

        KeepText(FadeDuration);
    }


    private void KeepText(float Duration)
    {
        Invoke("StartFadeOut", Duration);
    }

    private void StartFadeOut()
    {
        StartCoroutine(OnBeginFadeOut(FadeDuration));
    }

    private IEnumerator OnBeginFadeOut(float Duration)
    {
        int repeatCount = 50;
        // 이 코루틴이 호출되는 주기를 의미하는 변수
        // if coroutinePeriod = 1, 코루틴은 1초마다 호출될 것임.
        float coroutinePeriod = Duration / repeatCount;


        Color cachedColor = stageText.color;
        Color resultColor;

        int currentCount = repeatCount;
        while (currentCount > 0)
        {
            currentCount--;

            float decreaseAlphaPerLoop = cachedColor.a / repeatCount;
            if (stageText != null)
            {
                float tempAlpha = stageText.color.a;
                resultColor = new Color(cachedColor.r, cachedColor.g, cachedColor.b, tempAlpha - decreaseAlphaPerLoop);

                stageText.color = resultColor;

                yield return new WaitForSeconds(coroutinePeriod);
            }
            else
            {
                yield return null;
            }
        }
    }
}