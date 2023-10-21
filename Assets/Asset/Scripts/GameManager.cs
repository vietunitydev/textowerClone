using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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

            }
            currentIndex += 1;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("love hai dung:", ex.Message);
        }
    }
    
    public void PlayExplodeParticalSystem()
    {
            
        _positionParticalsystem = nextWord.letterHandlers[nextWord._hiddenIndex].transform;
        _particalsystemGameObject.transform.position = _positionParticalsystem.position;
        _particleSystem.Play();
    }

}
