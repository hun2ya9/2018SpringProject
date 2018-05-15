using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = new AudioManager();

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

    AudioSource bgm;
    AudioSource efx;

    public void PlayerSingle(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
    }
    // Use this for initialization
    void Start()
    {
        
    }
}
