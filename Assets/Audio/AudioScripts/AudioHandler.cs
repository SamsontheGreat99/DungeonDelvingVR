using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    // This should universally control what audio is playing
    public void ChangeMusic(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
