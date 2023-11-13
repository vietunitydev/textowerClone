using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWord : MonoBehaviour
{
    private int indexLevel;
    private int[] indexOfHeart;

    [SerializeField] LevelSO[] levelSO;
    [SerializeField] GameObject HealthHeart;
    [SerializeField] GenerateWord generateWord;

    WordTower wordTowerClone;
    WordHandler wordHandlerClone;

    List<GameObject> listHeart = new List<GameObject>();
    int indexHeartEnable;

    private void Start()
    {
        GameObject level = Instantiate(levelSO[indexLevel].tower, new Vector3(0, 0, 0), Quaternion.identity, transform);
        wordTowerClone = level.GetComponent<WordTower>();

        for (int i = 0; i < levelSO[indexLevel].numberWord; i++)
        {
            GameObject word = Instantiate(levelSO[indexLevel].Word,new Vector3(0,0+i*1.6f,0),Quaternion.identity,transform);
            wordHandlerClone = word.GetComponent<WordHandler>();
            wordTowerClone.wordHandlers.Add(wordHandlerClone);
        }
        indexOfHeart = new int[levelSO[indexLevel].numberHeart];
        StartCoroutine(SpawnHeartAfterSeconds());
    }


    IEnumerator SpawnHeartAfterSeconds()
    {
        yield return new WaitForSeconds(0.1f);
        SpawnHeart();
    }

    public void SpawnHeart()
    {
        for (int i= 0; i< levelSO[indexLevel].numberHeart; i++)
        {
            indexOfHeart[i] = ((levelSO[indexLevel].numberWord / 3)-1) * (i + 1);

        }
        int indexofheart = 0;

        for (int i = 0; i < levelSO[indexLevel].numberWord; i++)
        {

            if (i == indexOfHeart[indexofheart])
            {
                int indexHiddentWord = generateWord.tuples[i].Item1;
                Transform b = wordTowerClone.ReturnTranformOfHiddenNextLetter(i-1);

                GameObject _heart = Instantiate(HealthHeart, b.position, Quaternion.identity, transform);
                _heart.name = "Heart" + indexofheart;
                if (indexofheart < indexOfHeart.Length - 1)
                {
                    indexofheart++;
                }

                listHeart.Add(_heart);

            }
        }


    }

    public bool ReturnBoolCheckHeart(int indexParent)
    {
        foreach(int h in indexOfHeart)
        {
            if(h == indexParent)
            {
                UnenableHeart();
                return true;
            }
                

        }
        return false;
    }

    public void UnenableHeart()
    {
        SpriteRenderer heartSprite = listHeart[indexHeartEnable].GetComponent<SpriteRenderer>();
        heartSprite.enabled = false;
        indexHeartEnable++;
    }

    public int GetIndexPlayerPref()
    {
        return PlayerPrefs.GetInt("level",0);
    }
    public void SetIndexPlayerPref(int value)
    {
        PlayerPrefs.SetInt("level",value);
    }

    public int GetNumberWordofScene()
    {
        indexLevel = GetIndexPlayerPref();
        return levelSO[indexLevel].numberWord;
    }
}
