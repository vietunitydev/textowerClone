using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private bool isWinGame=false;
    private bool isLoseGame=false;
    private bool onSetting = false;
    public static bool music = false;
    
    public static bool sound = false;
    
    public Text musicText;
    public Text soundText;
    public Text levelText;
    public GameObject[] _UIgameObject;  
    public GameObject Setting;
    [SerializeField] AudioManager musicSource;
    private void Start()
    {
        ClickOnMusic();
        ClickOnSound();
    }

    public void Win()
    {
        isWinGame = true;
        isLoseGame = false;
        musicSource.PlaySound(1);
        _UIgameObject[0].SetActive(isWinGame); //UI Win
    }

    public void Lose()
    {
        isWinGame = false;
        isLoseGame = true;
        musicSource.PlaySound(2);
        _UIgameObject[1].SetActive(isLoseGame); //UI Lose
    }
    public void UpdateUILevel()
    {
        int currentSceneName = SceneManager.GetActiveScene().buildIndex;
        currentSceneName++;
        levelText.text = "Level " + currentSceneName;
    }

    public void OnSetting()
    {
        onSetting = !onSetting;
        Setting.SetActive(onSetting);

    }
    public void OnMusic()
    {
        music = !music;
        ClickOnMusic();
    }
    public void OnSound()
    {
        sound = !sound;
        ClickOnSound();
    }
    public void ClickOnMusic()
    {
        if (music)
        {
            musicText.text = "ON";
            musicSource.PlayMusic();

        }
        else
        {
            musicText.text = "OFF";
            musicSource.PauseMusic();
        }
    }
    public void ClickOnSound()
    {
        if (sound)
        {
            soundText.text = "ON";
            musicSource.PlaySound(0);
        }
        else
        {
            soundText.text = "OFF";
            musicSource.PasueSound();
        }
    }
}
