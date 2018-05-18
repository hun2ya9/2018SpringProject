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

    [Header("Audio")]
    public AudioSource bgm;
    public AudioSource efx;

    public void PlayerSingle(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
    }
}
