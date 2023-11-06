using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNumberManager : MonoBehaviour
{
    private Dictionary<string, int> sceneNumbers = new Dictionary<string, int>()
    {
        { "Level1", 10 },
        { "Level2", 15 },
        { "Level3", 20 },
        { "Level4", 25 },
        { "Level5", 30 },
        { "Level6", 35 },
    };

    public int GetNumberWordofScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(currentSceneName);
        if (sceneNumbers.ContainsKey(currentSceneName))
        {
            return sceneNumbers[currentSceneName];
        }
        else
        {
            return -1;
        }
    }

    public int GetNumberWord()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(currentSceneName);
        if (sceneNumbers.ContainsKey(currentSceneName))
        {
            return sceneNumbers[currentSceneName];
        }
        else
        {
            return -1;
        }
    }
}