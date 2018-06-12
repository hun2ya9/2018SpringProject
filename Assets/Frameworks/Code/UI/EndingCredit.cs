using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 엔딩 크레디트 => 스토리 설명과 게임 클리어시 띄우게 될 텍스트 올라가는효과
/// </summary>
public class EndingCredit : MonoBehaviour
{
    /// <summary>
    /// 올라가는 속도 - 인스펙터창에서 조절하셈 (1 ~ 1.5정도 생각중)
    /// </summary>
    public float creditSpeed;

    void Update()
    {
        ElevateText();
        Skip();
        StartGame();
    }
    private void ElevateText()
    {
        gameObject.transform.Translate(Vector3.up * creditSpeed);
    }
    /// <summary>
    /// 아무 키 누르면 빠르게 넘어가도록
    /// </summary>
    private void Skip()
    {
        if (Input.anyKey)
        {
            creditSpeed += 2;
        }
    }
    /// <summary>
    /// y 축 1100 이상 올라가면 게임 시작되도록 하겠음
    /// </summary>
    private void StartGame()
    {
        if (gameObject.transform.localPosition.y > 1300)
        {
            SceneManager.LoadScene("Opening");
        }
    }
}
