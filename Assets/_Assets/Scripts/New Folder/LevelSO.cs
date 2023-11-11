using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO",menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    public GameObject tower;
    public int numberWord;
    public GameObject Word;
    public int numberHeart;

}
