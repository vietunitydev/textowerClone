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

    static int levelIndex=0;

    public void ReadFile(List<string> wordTower, List<int> hiddenIndexList)
    {
            string words = wordsFilePath[levelIndex].text;
            Debug.Log(words);
            string hiddens = hiddenFilePath[levelIndex].text;
            Debug.Log(hiddens);

        try
        {
            using (StreamReader namesReader = new StreamReader(words))
            using (StreamReader agesReader = new StreamReader(hiddens))
            {    
                string word;
                string hidden;
                while ((word = namesReader.ReadLine()) != null && (hidden = agesReader.ReadLine()) != null)
                {
                    wordTower.Add(word);
                    if (int.TryParse(hidden, out int age))
                    {
                        hiddenIndexList.Add(age);
                    }
                    else
                    {
                        Debug.Log("fault");
                    }
                }
            }
            for (int i = 0; i < wordTower.Count; i++)
            {
                Debug.Log($" {wordTower[i]}, {hiddenIndexList[i]}");
            }
        }
        catch (IOException e)
        {
            Debug.Log("khong doc duoc tep tin: " + e.Message);
        }
    }

    public void ReadFileText(List<string> wordTower, List<int> hiddenIndexList)
    {
        string words = wordsFilePath[levelIndex].text;
        string hiddens = hiddenFilePath[levelIndex].text;

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
}
