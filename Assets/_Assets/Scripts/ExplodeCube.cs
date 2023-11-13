using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeCube : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        AddForceForChildrent();
    }

    private void AddForceForChildrent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            body = child.AddComponent<Rigidbody>();
            Vector3 randomDerection = new Vector3(Random.Range(-1, 2), Random.Range(-2, 2), Random.Range(2, 3));
            //Debug.Log(randomDerection);
            body.AddForce(randomDerection * 5, ForceMode.Impulse);
        }
    }
}
