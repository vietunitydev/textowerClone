using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class WordTower : MonoBehaviour

{
    private List<string> wordTower = new List<string>();
    private List<int> hiddenIndexList = new List<int>();

    [SerializeField] 
    public List<WordHandler> wordHandlers = new List<WordHandler>();
    public GameManager gameManager;
    public LoadData loadData;

    private void Awake()
    {
        //loadData.ReadFile(wordTower, hiddenIndexList);
        loadData.ReadFileText(wordTower, hiddenIndexList);  
        LoadWord();
    }
    private void Start()
    {
        
    }

    private void LoadWord()
    {
        for(int i = 0; i < wordHandlers.Count; i++) 
        {
            var word = wordTower[i];
            wordHandlers[i].SetWord(word, hiddenIndexList[i]);
            
        }
    }


    public void Check(char checkLetter, string _parentWord)
    {
        int index = wordTower.IndexOf(_parentWord);

        if (wordHandlers[index + 1].CheckWord(checkLetter))  //tham chieu den WordHandler tiep theo
        {
            if (index == wordTower.Count-2 ) // so luong cua word trong List word
            {

                gameManager.WinGame();
                Debug.Log("win game **** ");
            }

            gameManager.shakeObjectifTure();  // for(0-3)
            gameManager.SetColor(); // for (0-3)
            wordHandlers[index].HiddenWord(checkLetter); // hiSdden word was matched
            gameManager.UpdateCamera(); // di chuyen camera len khi correct (dotween)
    
        }
         
        else
        {
            gameManager.shakeObject();

            gameManager.SetCurrentHealth();
           
            if (gameManager.GetHeath()==0)
            {
                gameManager.LoseGame();
            }

        }
    }

    public Transform ReturnTranformOfHiddenNextLetter
        (char checkLetter, string _parentWord)
    {
        int index = wordTower.IndexOf(_parentWord);

        return wordHandlers[index + 1].letterHandlers[wordHandlers[index + 1]._hiddenIndex].transform;
    }

}
