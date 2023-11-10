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
    public int _levelIndex;
    public GameObject _followCamera;

    public CubeDotween _cubeDotween;
    private UIManager _uiManager;
    private UIHealth _uiHealth;
    private int numberWordofScene;
    [SerializeField] private int currentIndex = 0;
    
    public WordTower _wordTower;
    public WordHandler currentWord;
    public WordHandler nextWord;

    public LoadData loadData;
    public SceneNumberManager SceneNumberManager;

    private void Start()
    {
        _wordTower = FindObjectOfType<WordTower>();
        currentWord = _wordTower.wordHandlers[0];
        nextWord = _wordTower.wordHandlers[1];

        _uiHealth = GetComponent<UIHealth>();
        _uiManager = GetComponent<UIManager>();
        _uiHealth.UpdateHealth();
        numberWordofScene = SceneNumberManager.GetNumberWordofScene();
        SetColor();
        
    }

    // CAMERA FOLLOW WORDTOWER
    public void UpdateCamera()
    {
        _followCamera.transform.position = new Vector3(_followCamera.transform.position.x, _followCamera.transform.position.y + 1.5f, _followCamera.transform.position.z);
        _cubeDotween.camMove();
    }
    public void MovebyPositionFollowCamera()
    {
        _followCamera.transform.position = new Vector3(_followCamera.transform.position.x, _followCamera.transform.position.y + 1.5f, _followCamera.transform.position.z);
    }
    // WIN 
    public void WinGame()
    {
        _uiManager.Win();
    }
    //LOSE
    public void LoseGame()
    {      
        _uiManager.Lose();
        Debug.Log("***** YOU LOSE *****");
    }

    // SET HEATH IN UIManager
    public void SetCurrentHealth()
    {
        _uiHealth.SetHealth(1);
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
    
    public void PlayExplodeParticalSystem()
    {            
        //_positionParticalsystem = nextWord.letterHandlers[nextWord._hiddenIndex].transform;
        //_particalsystemGameObject.transform.position = _positionParticalsystem.position;
        //_particleSystem.Play();   
    }
    

    // co the la do 

    public void shakeObject()
    {
        for (int i = 0; i < 4; i++)
        {
            if (nextWord.letterHandlers[i] != null)
            {
                if ((nextWord.letterHandlers[i]._cubeDotween != null))
                {
                    Debug.LogWarning(nextWord.letterHandlers[i]._cubeDotween.name);
                    Debug.Log("*");
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
                    Debug.LogWarning(nextWord.letterHandlers[i]._cubeDotween.name);
                    Debug.Log("*");
                    nextWord.letterHandlers[i]._cubeDotween.shakeCubeWhenTure();
                }
                
            }
        }
    }

    public void ReloadScene()
    {
        LoadScenee._LoadScene(0);
    }

    public void UpdateCurrentWord()
    {
        currentIndex += 1;
        if (currentIndex > numberWordofScene -2 ) // n-2
            nextWord = _wordTower.wordHandlers[currentIndex];
        else nextWord = _wordTower.wordHandlers[currentIndex + 1];
        currentWord = _wordTower.wordHandlers[currentIndex];
        
    }

}
