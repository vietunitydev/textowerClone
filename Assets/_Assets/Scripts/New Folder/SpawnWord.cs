using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWord : MonoBehaviour
{
    [SerializeField] LevelSO[] levelSO;
    int k = 0;


    WordTower wordTowerClone;
    WordHandler wordHandlerClone;

    private void Start()
    {
        GameObject level = Instantiate(levelSO[k].tower, new Vector3(0, 0, 0), Quaternion.identity, transform);
        wordTowerClone = level.GetComponent<WordTower>();
        wordTowerClone.wordHandlers = new List<WordHandler>(levelSO[k].numberWord);

        for (int i = 0; i < levelSO[k].numberWord; i++)
        {
            GameObject word = Instantiate(levelSO[k].Word,new Vector3(0,0+i*1.6f,0),Quaternion.identity,transform);
            wordHandlerClone = word.GetComponent<WordHandler>();
            wordTowerClone.wordHandlers.Add(wordHandlerClone);
        }
    }

}
