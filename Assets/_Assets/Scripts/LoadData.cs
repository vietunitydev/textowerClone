using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public GenerateWord generateWord;

    public void ReadFileText(List<string> wordTower, List<int> hiddenIndexList)
    {
        wordTower.Clear();
        hiddenIndexList.Clear();

        var log = new StringBuilder();
        foreach (var tuple in generateWord.tuples)
        {
            hiddenIndexList.Add(tuple.Item1);
            wordTower.Add(tuple.Item2);
        }

        //Debug.Log("****************");
        //Debug.Log(wordTower.Count); //11
        //Debug.Log(hiddenIndexList.Count);
        //Debug.Log("****************");

    }

    public void SetIndexLevel(int value)
    {
        PlayerPrefs.SetInt("level", value);
        PlayerPrefs.Save();
    }

    public int GetIndexLevel()
    {
        int i = PlayerPrefs.GetInt("level", 0);
        return i;
    }

}

