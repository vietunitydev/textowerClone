using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private bool isWinGame=false;
    private bool isLoseGame=false;
    private bool onSetting = false;

    
    public Text musicText;
    public Text soundText;
    public Text levelText;
    public GameObject[] _UIgameObject;  
    public GameObject Setting;
    [SerializeField] AudioManager musicSource;

    private void Start()
    {

        DisplayIndexLevel();
        ClickOnMusic();
        ClickOnSound();
    }

    public void Win()
    {
        isWinGame = true;
        isLoseGame = false;
        UpdateUILevel();
        musicSource.PasueSound();
        musicSource.PlaySound(1);
        _UIgameObject[0].SetActive(isWinGame); //UI Win
    }

    public void Lose()
    {
        isWinGame = false;
        isLoseGame = true;
        musicSource.PasueSound();
        musicSource.PlaySound(2);
        _UIgameObject[1].SetActive(isLoseGame); //UI Lose
    }
    public void UpdateUILevel()
    {
        int nextIndexLevel = GetIndexLevelPlayerPrefs()+1;
        SetIndexLevelPlayerPrefs(nextIndexLevel);
    }
    public void DisplayIndexLevel()
    {
        levelText.text = "Level " + GetIndexLevelPlayerPrefs();
    }

    //  get set playerPrefs
    public int GetIndexLevelPlayerPrefs()
    {
        return PlayerPrefs.GetInt("indexLevel",1);
    }

    public void SetIndexLevelPlayerPrefs(int index)
    {
        PlayerPrefs.SetInt("indexLevel",index);
    }
    //---------
    public int GetMusicPlayerPrefs()
    {
        return PlayerPrefs.GetInt("music", 0);
    }

    public void SetMusicPlayerPrefs(int index)
    {
        PlayerPrefs.SetInt("music", index);
    }
    //--------
    public int GetSoundPlayerPrefs()
    {
        return PlayerPrefs.GetInt("sound", 0);
    }

    public void SetSoundPlayerPrefs(int index)
    {
        PlayerPrefs.SetInt("sound", index);
    }
    //------
    public static int GetPlayerPrefs (string name)
    {
        return PlayerPrefs.GetInt(name, 0);
    }

    public static void SetPlayerPrefs(string name, int index)
    {
        PlayerPrefs.SetInt(name, index);
    }


    //get set playerprefs
    // string : indexLevel, music, sound;





    //BUTTON  



    public void OnSetting()
    {
        onSetting = !onSetting;
        Setting.SetActive(onSetting);

    }
    public void OnMusic()
    {
        if (GetMusicPlayerPrefs() == 1)
        {
            SetMusicPlayerPrefs(0);
        }
        else SetMusicPlayerPrefs(1);
        ClickOnMusic();
    }
    public void OnSound()
    {
        if (GetSoundPlayerPrefs() == 1)
        {
            SetSoundPlayerPrefs(0);
        }
        else SetSoundPlayerPrefs(1);
        ClickOnSound();
    }


    //



    public void ClickOnMusic()
    {
        if (GetMusicPlayerPrefs()==1)
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
        if (GetSoundPlayerPrefs()==1)
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
