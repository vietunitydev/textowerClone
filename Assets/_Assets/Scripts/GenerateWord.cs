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
    public SceneNumberManager SceneNumberManager;
    public TextAsset textAsset;
    //[SerializeField] string text;
    [SerializeField] string[] words;
    public Dictionary<char, List<string>> dic = new Dictionary<char, List<string>>();
    public List<Tuple<int, string>> tuples = new List<Tuple<int, string>>();

    void ReadFile()
    {
        string text = textAsset.text;
        words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
    }

    //create dictionary luu cac key = letter
    //                          value = list cac tu co chua letter trong chu cua no

    void CreateDictionaryformText( string[] words, Dictionary<char, List<string>> dic)
    {
        for (int i = 0; i < words.Length; i++)
        {
            char[] letters = words[i].ToCharArray();

            for (int j = 0; j < 4; j++)
            {
                char letter = letters[j];
                if (!dic.ContainsKey(letter))
                {
                    dic[letter] = new List<string>();
                    //Debug.LogWarning(dic.Count);
                }
                dic[letter].Add(words[i]);
            }
        }
        var trinbuilder = new StringBuilder();

    }


    //create List gom cac tuple co kha nang chua
    // hidden letter ---- Word
    void CreateNewListFormDic(Dictionary<char, List<string>> dic, List<Tuple<int, string>> tuples)
    {
        // add tuple dau tien cho list
        System.Random ran = new System.Random();
        string temp = dic['A'][ran.Next(0, dic['A'].Count)];
        int hidden = 4;
        tuples.Add(Tuple.Create(hidden, temp));

        int n = SceneNumberManager.GetNumberWordofScene();

        for (int i = 0; i < n-1; i++)
        {

            int r = ran.Next(0, 3);
            char letter = temp[r];

            while (tuples.Any(tuple => tuple.Item2 == temp))
            {
                int w = ran.Next(0, dic[letter].Count);
                temp = dic[letter][w];
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

    private void Awake()
    {

        ReadFile();
        CreateDictionaryformText(words, dic);
        CreateNewListFormDic(dic, tuples);
        // Debug.LogWarning("****" + tuples.Count);    
    }
   
    
}
