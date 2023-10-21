using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class WordTower : MonoBehaviour

{
    private List<string> wordTower = new List<string>() { "TALL", "WILL" , "THIN", "BORN" ,"CRAB","CALM", "ONLY","YEAR","HIDE","CHAR" };
    private List<int> hiddenIndexList = new List<int>() {4,2,2,3,1,1,2,0,3,1};

    [SerializeField] public List<WordHandler> wordHandlers = new List<WordHandler>();
    public GameManager gameManager;


    private void Awake()
    {
        LoadWord(); 
    }

    //LOAD TU VAO LIST
    private void LoadWord()
    {
        for(int i = 0; i < wordHandlers.Count; i++) 
        {

            var word = wordTower[i];
            //Debug.Log(word);
            wordHandlers[i].SetWord(word, hiddenIndexList[i]);           
        }
    }


    public void Check(char checkLetter, string _parentWord)
    {
        int index = wordTower.IndexOf(_parentWord);
        Debug.Log(index);
        if (wordHandlers[index + 1].CheckWord(checkLetter))  //tham chieu den WordHandler tiep theo
        {
            if (index == 8) // so luong cua word trong List word
            {
                gameManager.WinGame();
                //Time.timeScale = 0f;
            }
            wordHandlers[index].HiddenWord(checkLetter); // hidden word was matched
            gameManager.UpdateCamera(); // di chuyen camera len khi correct (dotween) 
            gameManager.SetColor();
           
        }
         
        else
        {

            gameManager.PlayExplodeParticalSystem();
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
