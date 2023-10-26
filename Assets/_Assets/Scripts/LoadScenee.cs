using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenee : MonoBehaviour
{
    static string[] _sceneName = new string[] { "Level1", "Level2", "Level3" };

    static public void _LoadScene(int index)
    {
        Debug.Log(_sceneName[index]);
        SceneManager.LoadScene(_sceneName[index]);
    }
}
