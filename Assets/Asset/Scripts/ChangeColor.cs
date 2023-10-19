using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[System.Serializable]
public class ChangeColor : MonoBehaviour
{
    public Material greenWord;
    public Material yellowWord;
    public Material blueWord;
    //GameObject letter;
    Renderer Renderer;
  
    public void SetMaterialGreen()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material = greenWord;
    }
    public void SetMaterialYelllow()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material = yellowWord;
    }
    public void SetMaterialBlue()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material = blueWord;
    }
}
