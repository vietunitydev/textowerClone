using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    TextAsset[] wordsFilePath;
    [SerializeField]
    TextAsset[] hiddenFilePath;
    public GameManager gameManager;


    private void Awake()
    {
        Debug.Log("getindexlevel = " + GetIndexLevel());

    }

    public void ReadFileText(List<string> wordTower, List<int> hiddenIndexList)
    {
        //Debug.Log(GetIndexLevel());
        string words = wordsFilePath[GetIndexLevel()].text;
        string hiddens = hiddenFilePath[GetIndexLevel()].text;

        string[] word = words.Split('\n');
        string[] hidden = hiddens.Split('\n');
        foreach(var w in word)
        {
            wordTower.Add(w);
        }
        foreach(var h in hidden)
        {
            hiddenIndexList.Add(int.Parse(h));
        }

    }

    public void SetIndexLevel(int value)
    {
        PlayerPrefs.SetInt("level", value);
        PlayerPrefs.Save();
    }

    public int GetIndexLevel()
    {
        Debug.Log("5 x x x x "); 
        int i = PlayerPrefs.GetInt("level", 0);

        return i;
    }
}
