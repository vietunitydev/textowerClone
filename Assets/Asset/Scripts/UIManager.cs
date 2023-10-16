using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private bool isWinGame=false;
    private bool isLoseGame=false; 
    

    public GameObject[] _UIgameObject;  
    
    
    public void Win()
    {
        isWinGame = true;
        isLoseGame = false;
        _UIgameObject[0].SetActive(isWinGame); //UI Win
    }

    public void Lose()
    {
        isWinGame = false;
        isLoseGame = true;
        _UIgameObject[1].SetActive(isLoseGame); //UI Lose
    }

    
    
}
