using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeDotween : MonoBehaviour
{

    public Transform startTransform; 
    public Transform endTransform;   
    public float parabolaHeight = 5f; 
    public float duration = 2f;
    private LetterHandler letter;

    private void Start()
    {
        startTransform = transform;
        letter = GetComponent<LetterHandler>();

    }

    public void MoveToHiddenLetter(char checkLetter, string _parentWord)
    {
        //tinh diem tren parabol
        Vector3 midPoint = (startTransform.position + endTransform.position) / 2;
        midPoint -= Vector3.forward * parabolaHeight;



        transform.DOPath(new Vector3[] { startTransform.position, midPoint, endTransform.position }, duration, PathType.CatmullRom)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            gameObject.SetActive(false);
            //hien ra hiiden next letter
            //letter.ActivePartical();
            letter.Tower.Check(checkLetter, _parentWord);
            
        });
        
    }

    public void camMove()
    {
        Vector3 endpoi = endTransform.position;
        transform.DOMove(endpoi, 1f);
    }

    

    public void shakeObject()
    {
        // Sử dụng DOPunchPosition để tạo hiệu ứng rung
        transform.DOShakePosition(0.5f, 0.5f, 10 ,1f);
    }
    public void shakeObjectifTure()
    {
        Vector3 tran = startTransform.position;
        Vector3 midPoint = (startTransform.position + tran) / 2;
        midPoint += Vector3.forward * 2;

        //Vector3 midPoint = new Vector3();

        transform.DOPath(new Vector3[] { startTransform.position, midPoint, tran }, duration, PathType.CatmullRom).SetEase(Ease.Linear);
    }
}
