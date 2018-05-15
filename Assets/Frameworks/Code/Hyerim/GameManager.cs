using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
        DontDestroyOnLoad(this);
    }

    public float playTime;
    public int money;

    public AudioClip openingBGM;

    // Use this for initialization
    void Start()
    {
        AudioManager.instance.PlayerSingle(openingBGM);
    }

    // Update is called once per frame
    void Update()
    {
        RunTime();
    }

    private void RunTime()
    {
        playTime += Time.deltaTime;
    }

    public void GameClear()
    {

    }

    public void SettingWindow()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
