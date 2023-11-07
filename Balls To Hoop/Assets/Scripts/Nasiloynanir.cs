using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Nasiloynanir : MonoBehaviour
{
    public Image HandCursorNormal;
    public Sprite HandCursorPressed;
    public Sprite HandCursorUp;

    private void Start()
    {
        InvokeRepeating(nameof(CursorDegis), 1, .6f);
    }

    void CursorDegis()
    {
        if (HandCursorNormal.sprite == HandCursorUp)
        {
            HandCursorNormal.sprite = HandCursorPressed;
        }
        else
        {
            HandCursorNormal.sprite = HandCursorUp;
        }


    }

}
