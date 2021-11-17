using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundControlManager : MonoBehaviour
{
    AudioSource audioSource;
    float musicVolume = 0.4f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}
