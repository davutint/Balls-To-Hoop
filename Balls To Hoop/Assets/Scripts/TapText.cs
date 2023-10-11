using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TapText : MonoBehaviour
{
    Vector3 baslangıcScale;
    void Start()
    {
        baslangıcScale = transform.localScale;
        transform.DOScale((baslangıcScale / 2), 1f).SetLoops(-1,LoopType.Yoyo);
    }

}
