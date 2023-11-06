using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestSripts2 : MonoBehaviour
{
    [SerializeField] GameObject gameObjectPrefabs;

    private void Start()
    {
        StartCoroutine(InstanceGameObjectFrefab());
    }

    IEnumerator InstanceGameObjectFrefab()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            GameObject gobject = Instantiate(gameObjectPrefabs,Vector3.up,Quaternion.identity);
            yield return new WaitForSeconds(3);
            gobject.SetActive(false);
        }
    }
}
