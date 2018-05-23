using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioVolumeContol : MonoBehaviour
{
    public Slider[] volumeSlider;
    private AudioSource[] audioSource;

    private void Awake()
    {
        audioSource = GameObject.Find("AudioManager").GetComponents<AudioSource>();
    }
    public void VolumeSlider()
    {
        if (audioSource != null)
        {
            audioSource[0].volume = volumeSlider[0].value;
            audioSource[1].volume = volumeSlider[1].value;
        }
    }

}
