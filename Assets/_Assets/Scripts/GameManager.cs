using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int _levelIndex;
    public GameObject _followCamera;
    public GameObject _particalsystemGameObject;

    private ParticleSystem _particleSystem;
    private Transform _positionParticalsystem;

    public CubeDotween _cubeDotween;
    private UIManager _uiManager;
    private UIHealth _uiHealth;
    [SerializeField] private int currentIndex = 0; 
    public WordTower _wordTower;
    public WordHandler currentWord;
    public WordHandler nextWord;
    public LoadData loadData;


    private void Start()
    {
        _particleSystem = _particalsystemGameObject.GetComponent<ParticleSystem>();
        _particleSystem.Stop();
        _uiHealth = GetComponent<UIHealth>();
        _uiManager = GetComponent<UIManager>();
        _uiHealth.UpdateHealth();
        SetColor();
    }

    // CAMERA FOLLOW WORDTOWER
    public void UpdateCamera()
    {
        _followCamera.transform.position = new Vector3(_followCamera.transform.position.x, _followCamera.transform.position.y + 1.5f, _followCamera.transform.position.z);
        _cubeDotween.camMove();
    }
    // WIN 
    public void WinGame()
    {
        _levelIndex = loadData.GetIndexLevel()+1;

        Debug.Log("_levelIndex = " + _levelIndex);
        loadData.SetIndexLevel(_levelIndex);
        Debug.Log("*** " + loadData.GetIndexLevel());

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
        try
        {
            currentWord = _wordTower.wordHandlers[currentIndex];
            nextWord = _wordTower.wordHandlers[currentIndex + 1];
            for (int i = 0; i < 4; i++)
            {
                
                currentWord.letterHandlers[i].DisplayColorGreen();
                nextWord.letterHandlers[i].DisplayColorYellow();

                Debug.Log("setcolor" + i);

            }
            currentIndex += 1;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("***", ex.Message);
        }
    }
    
    public void PlayExplodeParticalSystem()
    {            
        _positionParticalsystem = nextWord.letterHandlers[nextWord._hiddenIndex].transform;
        _particalsystemGameObject.transform.position = _positionParticalsystem.position;
        _particleSystem.Play();   
    }
    

    // co the la do 

    public void shakeObject()
    {
        Debug.Log("font ----- game manager . shakeObjectifTure()");
        //shake cube if false check 
        for (int i = 0; i < 4; i++)
        {
            if (nextWord.letterHandlers[i] != null)
            {
                Debug.Log("shakeObject" + i);
                nextWord.letterHandlers[i]._cubeDotween.shakeCubeWhenFalse();
                
            }
            
        }
        Debug.Log("font ----- game manager . shakeObjectifTure()");
    }

    public void shakeObjectifTure()
    {
        Debug.Log("font ----- game manager . shakeObjectifTure()");
        for (int i = 0; i < 4; i++)
        {
            if (nextWord.letterHandlers[i] != null)
            {
                Debug.Log("shakeObject" + i);
                nextWord.letterHandlers[i]._cubeDotween.shakeCubeWhenTure();
                
            }
        }
        Debug.Log(" back ---- game manager . shakeObjectifTure()");
    }

    public void ReloadScene()
    {
        LoadScenee._LoadScene(loadData.GetIndexLevel());
    }

    public void LoadNextScene()
    {
        LoadScenee._LoadScene(loadData.GetIndexLevel());
    }

    public void ResetScene()
    {
        loadData.SetIndexLevel(0);
        LoadScenee._LoadScene(loadData.GetIndexLevel());
    }

}
