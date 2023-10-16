using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDotween : MonoBehaviour
{

    public Transform startTransform; 
    public Transform endTransform;   
    public float parabolaHeight = 5f; 
    public float duration = 2f;


    private void Start()
    {
        startTransform = transform;   
    }

    public void moveTo()
    {
        // Tính toán ?i?m trên ???ng parabol
        Vector3 midPoint = (startTransform.position + endTransform.position) / 2;
        midPoint -= Vector3.forward * parabolaHeight;

        //// Di chuy?n ??i t??ng theo ???ng parabol
        //transform.DOPath(new Vector3[] { startTransform.position, midPoint, endTransform.position }, duration, PathType.CatmullRom)
        //    .SetEase(Ease.Linear);

        transform.DOPath(new Vector3[] { startTransform.position, midPoint, endTransform.position }, duration, PathType.CatmullRom)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            // Ho?t ??ng hoàn t?t, ??t active(false)
            gameObject.SetActive(false);
        });
    }

   
}
