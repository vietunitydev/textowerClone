using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallFunction());

        Debug.Log("1");
    }

    public IEnumerator CallFunction()
    {
        Debug.Log("---");
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector3 (0, 1, 0);
        Debug.Log("---");
        yield return new WaitForSeconds(5f);
        Debug.Log("---");
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        Debug.Log("---//");
        gameObject.transform.position = new Vector3(0, -1, 0);
        Debug.Log("---//");
    }
}
