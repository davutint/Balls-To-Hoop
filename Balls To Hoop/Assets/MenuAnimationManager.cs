using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnimationManager : MonoBehaviour
{
    public Transform  Startobj, QuitObj, MarketObj,SettingsObj;


    private void Start()
    {

        StartMenuAnimations();

    }

    public void StartMenuAnimations()
    {
        Startobj.DOScale(new Vector2(.87f, 1.23f), .55f).SetLoops(-1, LoopType.Yoyo);
        Startobj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

        MarketObj.DOScale(new Vector2(.77f, 1.13f), .55f).SetLoops(-1, LoopType.Yoyo);
        MarketObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();


        SettingsObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        SettingsObj.DORotate(new Vector3(0, 0, 180), 5f).SetLoops(-1, LoopType.Incremental);
        QuitObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

    }
}
