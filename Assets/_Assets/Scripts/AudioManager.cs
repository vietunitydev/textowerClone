using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource Sound;
    [SerializeField] AudioClip[] changAudioClip;


    private void Start()
    {
        //Sound = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        backgroundMusic.Play();
    }
    public void PauseMusic()
    {
        backgroundMusic.Pause();
    }

    public void PlaySound(int index)
    {
        if(UIManager.sound) 
        {
            Sound.clip = changAudioClip[index];
            Sound.Play();
        }
        
    }
    public void PasueSound()
    {
        Sound.Pause();
    }
}
