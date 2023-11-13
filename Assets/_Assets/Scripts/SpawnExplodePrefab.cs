using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnExplodePrefab : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject gameObjectPrefabs;

    WordHandler nextWordHandler;
    Vector3 position;


    public void SpawnExplodeFrefab()
    {
        StartCoroutine(InstanceExplodeFrefab());
    }
    IEnumerator InstanceExplodeFrefab()
    {
        nextWordHandler = gameManager.nextWord;
        position = nextWordHandler.letterHandlers[nextWordHandler._hiddenIndex].transform.position;
        position = position + new Vector3(0, 0, 2);
        GameObject gobject = Instantiate(gameObjectPrefabs, position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        gobject.SetActive(false);
    }

}
