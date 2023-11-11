using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _levelIndex;
    private UIManager _uiManager;
    private UIHealth _uiHealth;
    private int numberWordofScene;
    [SerializeField] private int currentIndexWord = 0;

    public GameObject _followCamera;
    public CubeDotween _cubeDotween;
    public WordTower _wordTower;
    public WordHandler currentWord;
    public WordHandler nextWord;

    public LoadData loadData;
    public SpawnWord spawnWord;


    private void Start()
    {
        _wordTower = FindObjectOfType<WordTower>();
        currentWord = _wordTower.wordHandlers[0];
        nextWord = _wordTower.wordHandlers[1];

        _uiHealth = GetComponent<UIHealth>();
        _uiManager = GetComponent<UIManager>();
        _uiHealth.UpdateHealth();
        numberWordofScene = spawnWord.GetNumberWordofScene();
        SetColor();
        
    }

    // CAMERA FOLLOW WORDTOWER
    public void UpdateCamera()
    {
        _followCamera.transform.position = new Vector3(_followCamera.transform.position.x, _followCamera.transform.position.y + 1.6f, _followCamera.transform.position.z);
        _cubeDotween.camMove();
    }
    public void MovebyPositionFollowCamera()
    {
        _followCamera.transform.position = new Vector3(_followCamera.transform.position.x, _followCamera.transform.position.y + 1.5f, _followCamera.transform.position.z);
    }
    // WIN 
    public void WinGame()
    {
        // SO index + 1
        int levelIndex = spawnWord.GetIndexPlayerPref()+1;
        spawnWord.SetIndexPlayerPref(levelIndex);
        _uiManager.Win();
    }
    //LOSE
    public void LoseGame()
    {      
        _uiManager.Lose();
        Debug.Log("***** YOU LOSE *****");
    }

    // SET HEATH IN UIManager
    public void SetCurrentHealth(int damage)
    {
        _uiHealth.SetHealth(damage);
        _uiHealth.UpdateHealth();
    }
    public int GetHeath()
    {
        return _uiHealth.currenHealth;
    }

    public void SetColor()
    {
        for (int i = 0; i < 4; i++)
        {
            nextWord.letterHandlers[i].DisplayColorYellow();
            currentWord.letterHandlers[i].DisplayColorGreen();
        }
    }
        

    public void shakeObject()
    {
        for (int i = 0; i < 4; i++)
        {
            if (nextWord.letterHandlers[i] != null)
            {
                if ((nextWord.letterHandlers[i]._cubeDotween != null))
                {
                    nextWord.letterHandlers[i]._cubeDotween.shakeCubeWhenFalse();
                }
            }
        }
    }

    public void shakeObjectifTure()
    {
        for (int i = 0; i < 4; i++)
        {
            if (nextWord.letterHandlers[i] != null)
            {
                if ((nextWord.letterHandlers[i]._cubeDotween != null))
                {
                    //Debug.LogWarning(nextWord.letterHandlers[i]._cubeDotween.name);
                    nextWord.letterHandlers[i]._cubeDotween.shakeCubeWhenTure();
                }
                
            }
        }
    }

    public void ReloadScene()
    {
        LoadScenee.LoadPlayScene(0);
    }

    public void UpdateCurrentWord()
    {
        currentIndexWord += 1;
        if (currentIndexWord > numberWordofScene -2 ) // n-2
            nextWord = _wordTower.wordHandlers[currentIndexWord];
        else nextWord = _wordTower.wordHandlers[currentIndexWord + 1];
        currentWord = _wordTower.wordHandlers[currentIndexWord];
        
    }

    public bool GetBoolCheckHeart(int indexParent)
    {
        return spawnWord.ReturnBoolCheckHeart(indexParent);
    }
}
