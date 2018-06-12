using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
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
    public int skinNumber;
    public Color lineStartColor;
    public Color lineEndColor;

    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        LoadData();
    }

    void Update()
    {
        RunGameTime();
    }

    [Button(name: "플레이어 스킨변경")]
    public void ChangePlayerSkin()
    {
        if (skinNumber < playerSkin.Count - 1)
        {
            playerPrefab = playerSkin[++skinNumber];
        }
        else
        {
            skinNumber = 0;
            playerPrefab = playerSkin[skinNumber];
        }
        SaveData();
    }

    [Button(name: "로프 스킨변경")]
    public void ChangeRopeSkin()
    {
        lineStartColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        lineEndColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        SaveData();
    }

    private void LoadData()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        skinNumber = PlayerPrefs.GetInt("PlayerSkin", 0);
        lineStartColor = new Color(PlayerPrefs.GetFloat("StartR", 0), PlayerPrefs.GetFloat("StartG", 0), PlayerPrefs.GetFloat("StartB", 0));
        lineEndColor = new Color(PlayerPrefs.GetFloat("EndR", 0), PlayerPrefs.GetFloat("EndG", 0), PlayerPrefs.GetFloat("EndB", 0));
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("PlayerSkin", skinNumber);

        PlayerPrefs.SetFloat("StartR", lineStartColor.r);
        PlayerPrefs.SetFloat("StartG", lineStartColor.b);
        PlayerPrefs.SetFloat("StartB", lineStartColor.g);
        PlayerPrefs.SetFloat("EndR", lineEndColor.r);
        PlayerPrefs.SetFloat("EndG", lineEndColor.g);
        PlayerPrefs.SetFloat("EndB", lineEndColor.b);
        PlayerPrefs.Save();
    }

    //// Main 씬으로 전환하면 호출
    private void ChangedActiveScene(Scene current, Scene next)
    {
        var scene = next.name;

        if (scene == "Main")
        {
            AudioManager.instance.PlaySingle(mainBGM);
            currentPlayer = Instantiate(playerPrefab, new Vector3(-6, -4, 0), Quaternion.identity, null);
        }
        // 게임 -> 오프닝으로 되돌아가면 컴퓨터에 현재 돈 저장
        if (scene == "Opening")
        {
            playTime = 0;
            print("게임 종료. 현재 돈 저장, 시간 초기화 ");
        }
        SaveData();
    }
    private void RunGameTime()
    {
        playTime += Time.deltaTime;
    }

    public void GameClear()
    {
        GameObject.Find("EndingCredit").SetActive(true);
        SaveData();
    }

    public void ExitGame()
    {
        SaveData();
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
