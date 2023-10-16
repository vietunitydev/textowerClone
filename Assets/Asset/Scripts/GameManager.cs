using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Camera _camera;
    private UIManager _UIManager;
    private UIHealth _UIHealth;
    private void Start()
    {
        _UIHealth = GetComponent<UIHealth>();
        _UIManager = GetComponent<UIManager>();
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _UIHealth._Update();

    }
    // CAMERA FOLLOW WORDTOWER
    public void UpdateCamera()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y + 1.5f, _camera.transform.position.z);

    }
    // WIN 
    public void WinGame()
    {
        _UIManager.Win();
    }
    //LOSE
    public void LoseGame()
    {      
        _UIManager.Lose();
        Debug.Log("***** YOU LOSE *****");
    }

    // SET HEATH IN UIManager
    public void SetCurrentHealth()
    {
        _UIHealth.SetHealth(1);
        _UIHealth._Update();
    }
    public int GetHeath()
    {
        return _UIHealth.currenHealth;
    }

    //public void SetinActiveHiddenLetter(GameObject o) 
    //{
    //    _UIManager.inActiveHiddenLetter(o);
    //}



}
