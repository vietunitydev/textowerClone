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
    public AudioManager audioManager;
    public List<string> WordTower1 { get => wordTower; set => wordTower = value; }
    public List<int> HiddenIndexList { get => hiddenIndexList; set => hiddenIndexList = value; }

    public void Start()
    {

        GameObject audioM = GameObject.FindGameObjectWithTag("AudioManager");
        GameObject spawnEP = GameObject.FindGameObjectWithTag("SpawnExplodePrefabs");
        audioManager = audioM.GetComponent<AudioManager>();
        spanwExplodePrefab = spawnEP.GetComponent<SpawnExplodePrefab>();
        GameObject gameM = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameM.GetComponent<GameManager>();
        loadData = gameM.GetComponent<LoadData>();


        loadData.ReadFileText(wordTower, hiddenIndexList);
        Debug.Log("wordTower ReadFileText");
        //wordTower.Log(); // là 1 list nh?ng count b?ng 0
        //hiddenIndexList.Log(); // là 1 list nh?ng count b?ng 0
        LoadWord();
    }
    

    private void LoadWord()
    {
        for(int i = 0; i < wordHandlers.Count; i++) 
        {
            var word = wordTower[i];
            wordHandlers[i].SetWord(word, hiddenIndexList[i],i);
            wordHandlers[i].Init();
        }
    }


    public void Check(char checkLetter, int _indexParentWord)
    {
       
        if (wordHandlers[_indexParentWord + 1].CheckWord(checkLetter))  //tham chieu den WordHandler tiep theo
        {
            audioManager.PlaySound(4);

            if (_indexParentWord == wordTower.Count-2 ) // so luong cua word trong List word
            {

                gameManager.WinGame();
                Debug.Log("win game **** ");
            }

            gameManager.shakeObjectifTure();
            gameManager.UpdateCurrentWord();
            gameManager.SetColor(); // for (0-3)
            wordHandlers[_indexParentWord].HiddenWord(checkLetter); // hiSdden word was matched
            gameManager.UpdateCamera(); // di chuyen camera len khi correct (dotween)
            if (gameManager.GetBoolCheckHeart(_indexParentWord+1))
            {
                gameManager.SetCurrentHealth(1);
            }
            
        }

        else
        {
            gameManager.shakeObject();
            audioManager.PlaySound(3);
            spanwExplodePrefab.SpawnExplodeFrefab();
            gameManager.SetCurrentHealth(-1); //  khi sai
            if (gameManager.GetHeath() == 0)
            {
                gameManager.LoseGame();
                gameManager.MovebyPositionFollowCamera();
            }
            Debug.LogError("False");
        }
    }

    public Transform ReturnTranformOfHiddenNextLetter( int _indexParentWord)
    {
        return wordHandlers[_indexParentWord + 1].letterHandlers[wordHandlers[_indexParentWord + 1]._hiddenIndex].transform;
    }

}
