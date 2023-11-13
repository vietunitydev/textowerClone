using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource Sound;
    [SerializeField] AudioClip[] changAudioClip;


    //
    public void PlayMusic()
    {
        backgroundMusic.Play();
    }
    public void PauseMusic()
    {
        backgroundMusic.Pause();
    }
    //




    public void PlaySound(int index)
    {
        if(UIManager.GetPlayerPrefs("sound")==1) 
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
