using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using UnityEngine.PostProcessing;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    [Header("Values")]
    public float playTime;
    public int money;

    [Space]
    [Header("Audio")]
    public AudioClip mainBGM;
    public AudioClip ropeSound;
    public AudioClip birdSound;
    public AudioClip coinSound;
    public AudioClip flySound;
    public AudioClip hitSound;
    public AudioClip landingSound;
    public AudioClip potalSound;

    public List<GameObject> playerSkin = new List<GameObject>();
    
    // 플레이어 프리펩 -> 상점에서 구매시 변경됨. 디폴트값으로는 Player_Blue
    public GameObject playerPrefab;

    // 현재 플레이 중인 플레이어
    public GameObject currentPlayer;

    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        PlayerPrefs.GetInt("Money", money);
    }

    void Update()
    {
        RunGameTime();
    }

    private int skinNumber;
    [Button(name: "플레이어 스킨변경")]
    public void ChangeSkin()
    {
        if (skinNumber < playerSkin.Count)
        {
            playerPrefab = playerSkin[skinNumber++];
        }
        else
        {
            skinNumber = 0;
        }
    }

    //// Main 씬으로 전환하면 호출
    private void ChangedActiveScene(Scene current, Scene next)
    {
        var scene = next.name;

        if (scene == "Main")
        {
            AudioManager.instance.PlaySingle(mainBGM);
            currentPlayer = Instantiate(playerPrefab, new Vector3(-6, -4, 0), Quaternion.identity,null);
        }
        // 게임 -> 오프닝으로 되돌아가면 컴퓨터에 현재 돈 저장
        if (scene == "Opening")
        {
            print("게임 종료. 현재 돈 저장");
            PlayerPrefs.SetInt("Money", money);
        }
    }
    private void RunGameTime()
    {
        playTime += Time.deltaTime;
    }

    public void GameClear()
    {
        GameObject.Find("EndingCredit").SetActive(true);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Money", money);
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
