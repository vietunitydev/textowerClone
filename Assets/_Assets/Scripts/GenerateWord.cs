using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Text;

public class GenerateWord : MonoBehaviour
{
    /// <summary>
    /// //////////////////////////
    /// </summary>
    public SpawnWord spawnWord;
    public TextAsset textGenerate;
    public TextAsset textCorrect;
    
    [SerializeField] string[] words;
    [SerializeField] string[] wordsCorrect;

    public Dictionary<char, List<string>> dicGenerate = new Dictionary<char, List<string>>();
    public Dictionary<char, Dictionary<int, List<string>>> dicCorrect = new Dictionary<char, Dictionary<int, List<string>>>();
    public List<Tuple<int, string>> tuples = new List<Tuple<int, string>>();

    void ReadFile()
    {
        string text = textGenerate.text;
        words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    }

    //create dictionary luu cac key = letter
    //                          value = list cac tu co chua letter trong chu cua no

    void CreateDictionaryformText()
    {
        for (int i = 0; i < words.Length; i++)
        {
            char[] letters = words[i].ToCharArray();

            for (int j = 0; j < 4; j++)
            {
                char letter = letters[j];
                if (!dicGenerate.ContainsKey(letter))
                {
                    dicGenerate[letter] = new List<string>();
                    //Debug.LogWarning(dic.Count);
                }
                dicGenerate[letter].Add(words[i]);
            }
        }
        var trinbuilder = new StringBuilder();

    }


    //create List gom cac tuple co kha nang chua
    // hidden letter ---- Word
    void CreateNewListFormDic()
    {
        // add tuple dau tien cho list
        System.Random ran = new System.Random();
        string temp = dicGenerate['A'][ran.Next(0, dicGenerate['A'].Count)];
        int hidden = 4;
        tuples.Add(Tuple.Create(hidden, temp));

        int n = spawnWord.GetNumberWordofScene();
        int randomIndexLetter = 4;
        for (int i = 0; i < n-1; i++)
        {

            while (randomIndexLetter==hidden)
            {
                randomIndexLetter = ran.Next(0, 3);
            }

            char letter = temp[randomIndexLetter];

            while (tuples.Any(tuple => tuple.Item2 == temp))
            {
                int randomWord = ran.Next(0, dicGenerate[letter].Count);
                temp = dicGenerate[letter][randomWord];
            }
            
            for (int j = 0; j < 4; j++)
            {
                if (temp[j] == letter)
                {
                    hidden = j;
                    break;
                }
            }
            tuples.Add(Tuple.Create(hidden, temp));

        }
    }



    //=================

    void ReadFileCorrect()
    {
        string text = textCorrect.text;
        wordsCorrect = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    }

    //create dictionary luu cac key = letter
    //                          value = list cac tu co chua letter trong chu cua no

    void CreateDictionaryformTextCorrect()
    {
        for (int i = 0; i < wordsCorrect.Length; i++)
        {
            char[] letters = wordsCorrect[i].ToCharArray();

            for (int j = 0; j < 4; j++)
            {
                char letter = letters[j];
                if (!dicCorrect.ContainsKey(letter))
                {
                    dicCorrect[letter] = new Dictionary<int, List<string>>();
                }

                Dictionary<int, List<string>> dicSub = dicCorrect[letter];
                if (!dicSub.ContainsKey(j))
                {
                    dicSub[j] = new List<string>();
                }


                dicSub[j].Add(wordsCorrect[i]);

            }

        }

    }



    //================



    private void Awake()
    {

        ReadFile();
        CreateDictionaryformText();
        CreateNewListFormDic();
        //----correct

        ReadFileCorrect();
        CreateDictionaryformTextCorrect();
    }


}
