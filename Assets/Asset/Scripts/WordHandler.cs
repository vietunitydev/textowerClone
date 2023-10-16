using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;



public class WordHandler : MonoBehaviour
{
    [SerializeField] public string _word;
    [SerializeField] public int _hiddenIndex;

    private List<char> letters = new List<char>();
    [SerializeField] public List<LetterHandler> letterHandlers;
    
    
    public GameManager gameManager;

    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        
        letters = new List<char>(_word.ToCharArray());
        for(int i = 0; i < letterHandlers.Count; i++)
        {     
            var letter = letters[i];
            var letterHandler = letterHandlers[i];

            if(i == _hiddenIndex)
            {
                //gameManager.SetinActiveHiddenLetter(letterHandlers[i]);
            }

            letterHandler.SetLetter(letter, i ,_word, i == _hiddenIndex);
         
        }       
    }
    
    internal void SetWord(string word, int hiddenIndex)
    {
        _word = word;
        _hiddenIndex = hiddenIndex;
    }
    

    //KIEM TRA VOI HIDDEN XEM CO TRUNG' HAY KHONG
    public bool CheckWord(char checkWord)
    {
        if (checkWord == letters[_hiddenIndex])
        {
          
            letterHandlers[_hiddenIndex].SetActiveWord();
            letterHandlers[_hiddenIndex].Display(checkWord);
            return true;
        }
        else
        {
            
            Debug.Log("WordHandler **** Tru mau "); // code tru mau o day
            return false;
        }
    }

    // HIDDEN WORD DA CHECK XONG, gui vao vi tri vua chon
    public void HiddenWord(char checkLetter)
    {
        for(int i = 0; i < 4; i++)
        {
            //if (letterHandlers[i]._letter == checkLetter) letterHandlers[i].SetinActiveWord();
            letterHandlers[i].Display(' ');
         
        }
    } 
    

}