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
    public int _indexletter;

    public ChangeColor letterDefault;
    private string _parentWord; //tu nay thuoc tu nao
    public  WordTower Tower; 
    public CubeDotween _cubeDotween;
    

    private void Awake()
    {
        Tower = FindObjectOfType<WordTower>();
        _cubeDotween = GetComponent<CubeDotween>();

        gameObject.GetComponent<ChangeColor>();
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
        if (_indexletter < 13)
        {
            _cubeDotween.endTransform = Tower.ReturnTranformOfHiddenNextLetter(checkLetter, _parentWord);
        }
        else _cubeDotween.endTransform = transform;

        _cubeDotween.MoveToHiddenLetter(checkLetter,_parentWord);


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
