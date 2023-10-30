using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UIElements;

public class LetterHandler : MonoBehaviour
{
    [SerializeField] private Text lable; 
    public char _letter; // 


    public ChangeColor letterDefault;
    private int _indexParentWord; //tu nay thuoc tu nao
    public  WordTower Tower; 
    public CubeDotween _cubeDotween;
    

    private void Start()
    {
        Tower = FindObjectOfType<WordTower>();
        gameObject.GetComponent<ChangeColor>();
    }

    public void Display(char letter)
    {

        lable.text = letter.ToString().ToUpper();
    }

    //set tu data, neu hidden thi setsactive(false);
    internal void SetLetter(char letter, int indexletter, int indexParentWord, bool hidden = false)
    {

        _letter = letter;
        _indexParentWord = indexParentWord;


        if (!hidden)
        {

            Display(_letter);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //set active va set inactive
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

        //var checkLetter = _letter;

        if (true)
        {
               _cubeDotween.endTransform = Tower.ReturnTranformOfHiddenNextLetter(checkLetter, _indexParentWord);
        }
        //else _cubeDotween.endTransform = transform;

        _cubeDotween.endTransform = Tower.ReturnTranformOfHiddenNextLetter(checkLetter, _indexParentWord);
        _cubeDotween.MoveToHiddenLetter(checkLetter, _indexParentWord);

    }
    
    private void OnValidate()
    {
        Display(_letter);
    }

    public void DisplayColorGreen()
    {

        letterDefault.SetMaterialGreen();
    }
    public void DisplayColorYellow() 
    { 
        letterDefault.SetMaterialYelllow();
    }
    public void DisplayCollorBlue()
    {
        letterDefault.SetMaterialBlue();
    }
}
