using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNumberManager : MonoBehaviour
{
    private Dictionary<string, int> sceneNumbers = new Dictionary<string, int>()
    {
        { "Level1", 10 },
    };

    public int GetNumberWordofScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
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