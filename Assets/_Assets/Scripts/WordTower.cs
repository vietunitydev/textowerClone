using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class WordTower : MonoBehaviour
{
    //public static WordTower instance;
    [SerializeField] SpawnExplodePrefab spanwExplodePrefab;
    private List<string> wordTower = new List<string>();
    private List<int> hiddenIndexList = new List<int>();
    public List<WordHandler> wordHandlers = new List<WordHandler>();
    public GameManager gameManager;
    public LoadData loadData;
    [SerializeField] AudioManager audioManager;
    public List<string> WordTower1 { get => wordTower; set => wordTower = value; }
    public List<int> HiddenIndexList { get => hiddenIndexList; set => hiddenIndexList = value; }

    private void Start()
    {
        loadData.ReadFileText(wordTower, hiddenIndexList);
        wordTower.Log(); // là 1 list nh?ng count b?ng 0
        hiddenIndexList.Log(); // là 1 list nh?ng count b?ng 0
        LoadWord();

    }
    

    private void LoadWord()
    {
        for(int i = 0; i < wordHandlers.Count; i++) 
        {
            //Debug.Log("*************" + wordTower[i]);
            var word = wordTower[i];
            wordHandlers[i].SetWord(word, hiddenIndexList[i],i);
            wordHandlers[i].Init();
        }
    }


    public void Check(char checkLetter, int _indexParentWord)
    {
        //int index = wordTower.IndexOf(_parentWord);

        if (wordHandlers[_indexParentWord + 1].CheckWord(checkLetter))  //tham chieu den WordHandler tiep theo
        {
            if (_indexParentWord == wordTower.Count-2 ) // so luong cua word trong List word
            {

                gameManager.WinGame();
                Debug.Log("win game **** ");
            }

            gameManager.shakeObjectifTure();
            audioManager.PlaySound(4);
            gameManager.UpdateCurrentWord();
            gameManager.SetColor(); // for (0-3)
            wordHandlers[_indexParentWord].HiddenWord(checkLetter); // hiSdden word was matched
            gameManager.UpdateCamera(); // di chuyen camera len khi correct (dotween)
        }

        else
        {
            //StartCoroutine(WaitToNextFunc());
            gameManager.shakeObject();
            audioManager.PlaySound(3);
            spanwExplodePrefab.SpawnExplodeFrefab();
            gameManager.SetCurrentHealth();
            if (gameManager.GetHeath() == 0)
            {
                gameManager.LoseGame();
                gameManager.MovebyPositionFollowCamera();
            }
            Debug.LogError("False");
        }
    }

    public Transform ReturnTranformOfHiddenNextLetter(char checkLetter, int _indexParentWord)
    {
        //int index = wordTower.IndexOf(_parentWord);

        return wordHandlers[_indexParentWord + 1].letterHandlers[wordHandlers[_indexParentWord + 1]._hiddenIndex].transform;
    }

}
