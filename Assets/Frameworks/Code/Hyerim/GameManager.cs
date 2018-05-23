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
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    [Header("Values")]
    public float playTime;
    public int money;

    [Space]
    [Header("Audio")]
    public AudioClip openingBGM;

    void Start()
    {
        AudioManager.instance.PlayerSingle(openingBGM);
    }

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
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
