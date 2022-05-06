using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniversalAudioSwitch : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();

    }
    //public AudioClip audioClip;
    public void ChangeMusic(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

    public void MusicVolume(Slider slider)
    {
        if(audioSource != null)
        {
            audioSource.volume = slider.value;

        }
    }
}
