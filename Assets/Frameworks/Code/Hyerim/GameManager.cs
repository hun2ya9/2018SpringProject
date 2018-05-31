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

    [Space]
    [Header("Special Effect")]
    private PostProcessingBehaviour postProcessing;
    private VignetteModel vignette;
    public float hitEffectTime;
    private Color hitColor = new Color(0,255,255);

    public static Action OnHitEffect;

    [Space]
    [Header("Fever")]
    public List<GameObject> feverObject = new List<GameObject>();
    public List<Image> feverImage = new List<Image>();
    public bool[] hasFever;
    

    void Start()
    {
        hasFever = new bool[feverImage.Count];
        AudioManager.instance.PlaySingle(mainBGM);
        // SceneManager.activeSceneChanged += ChangedActiveScene;
        OnHitEffect += HitEffect;
        GameStartSetting();
    }

    void Update()
    {
        RunGameTime();
    }

    //// Main 씬으로 전환하면 호출
    //private void ChangedActiveScene(Scene current, Scene next)
    //{
    //    var scene = next.name;

    //    if (scene == "Main")
    //    {
    //        GameStartSetting();
    //    }
    //}

    // Main 씬 전환시 호출
    public void GameStartSetting()
    {
        print("Main씬 호출");
        postProcessing = Camera.main.GetComponent<PostProcessingBehaviour>();
        vignette = postProcessing.profile.vignette;
    }

    public void HitEffect()
    {
        print("피격당함");
        vignette.enabled = true;
        print(vignette.enabled);
        Invoke("HitEffectInvoke", hitEffectTime);
    }

    private void HitEffectInvoke()
    {
        vignette.enabled = false;
        Throwhook.RopeCancle();
    }

    private void RunGameTime()
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

    public void FeverCheck(Collider2D col)
    {
        var feverList = feverObject;
        int totalCount = 0;
        for (int i = 0; i < feverList.Count; i++)
        {
            if (col.gameObject.Equals(feverList[i]))
            {
                hasFever[i] = true;
                totalCount++;
                ChangeAlpha(feverImage[i]);
            }
        }
        if (totalCount == hasFever.Length)
        {
            //모든 fever를 먹었을 때
        }

    }

    public void ChangeAlpha(Image fever)
    {
        fever.color = new Color(1, 1, 1);
    }
}
