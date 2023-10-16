using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class LetterHandler : MonoBehaviour
{
    [SerializeField] private Text lable; 
    [SerializeField] public char _letter; // 
    [SerializeField] public int _indexletter;
    private string _parentWord; //tu nay thuoc tu nao
    [SerializeField] WordTower Tower; // tham chieu den tower
    public CubeDotween _cubeDotween;

    private void Start()
    {
        Tower = FindObjectOfType<WordTower>();
        _cubeDotween = GetComponent<CubeDotween>();
    }

    public void Display(char letter)
    {

        lable.text = letter.ToString().ToUpper();
    }

    //set tu data, neu hidden thi setsactive(false);
    internal void SetLetter(char letter, int indexletter, string parentWord, bool hidden = false)
    {

        _letter = letter;
        _parentWord = parentWord;
        _indexletter = indexletter;

        if (!hidden)
        {

            Display(_letter);
        }
        else
        {
            gameObject.SetActive(false);
            //Display(' ');
        }
    }

    //set active va set Inactive
    internal void SetActiveWord()
    {
        gameObject.SetActive(true);
    }
    internal void SetinActiveWord()
    {
        gameObject.SetActive(false);
    }



    private void OnMouseDown() // an vao tu nao
    {
        LetterHandler letter = gameObject.GetComponent<LetterHandler>();
        var checkLetter = letter._letter;
        _cubeDotween.endTransform = Tower.TransForm(checkLetter,_parentWord);
        _cubeDotween.moveTo();

        Tower.Check(checkLetter, _parentWord);
        //if (!Tower.Check(checkLetter, _parentWord)) //neu khong check dung
        //{

        //    //letter.SetinActiveWord();
        //}

    }
    
    private void OnValidate()
    {
        Display(_letter);
    }

}
