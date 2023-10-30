using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;



public class WordHandler : MonoBehaviour
{
    public string _word;
    public int _hiddenIndex;
    public int _indexWord;

    private List<char> letters = new List<char>();
    public List<LetterHandler> letterHandlers;
    
    
    public GameManager gameManager;

    private void Start()
    {
        //Init();
    }
    
    public void Init()
    {
        
        letters = new List<char>(_word.ToCharArray());
        
        for(int i = 0; i < letterHandlers.Count && i < letters.Count; i++)
        {
            //Debug.Log(letters[i]);
            var letter = letters[i];
            var letterHandler = letterHandlers[i];

            //Debug.Log(letter);
            if (i == _hiddenIndex)
            {
                //gameManager.SetinActiveHiddenLetter(letterHandlers[i]);
            }

            letterHandler.SetLetter(letter, i, _indexWord, i == _hiddenIndex);

        }
    }
    
    internal void SetWord(string word, int hiddenIndex, int indexWord)
    {
        _word = word;
        _hiddenIndex = hiddenIndex;
        _indexWord = indexWord;
    }
    

    //KIEM TRA VOI HIDDEN XEM CO TRUNG' HAY KHONG
    public bool CheckWord(char checkWord)
    {
        Debug.Log("world hander . check()");
        if (checkWord == letters[_hiddenIndex])
        {          
            letterHandlers[_hiddenIndex].SetActiveWord();
            letterHandlers[_hiddenIndex].Display(checkWord);
            Debug.Log("world hander . check() -- true");
            return true;
        }
        else
        {
            Debug.Log("world hander . check() -- false");
            return false;
        }
    }

    // HIDDEN WORD DA CHECK XONG, gui vao vi tri vua chon
    public void HiddenWord(char checkLetter)
    {
        for(int i = 0; i < 4; i++)
        {

            letterHandlers[i].Display(' ');
            letterHandlers[i].DisplayCollorBlue();

            //Debug.Log("Hiddenword" + i);
        }
    } 
    
}
