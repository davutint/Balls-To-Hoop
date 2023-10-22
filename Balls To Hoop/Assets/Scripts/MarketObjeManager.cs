using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MarketObjeManager : MonoBehaviour
{
    public GameObject[] MarketObjeleri;
    private int objenumarası;

    private void Start()
    {
        for (int i = 0; i < MarketObjeleri.Length; i++)
        {
            if (MarketObjeleri[i].activeSelf)
            {
                objenumarası = MarketObjeleri[i].GetComponent<marketContent>().objid;
                Debug.Log("AKTİF OBJ NUMARASI : "+objenumarası);
            }
        }
        /*foreach (var item in MarketObjeleri)
        {
            if (item.activeSelf)
            {
                objenumarası = item.GetComponent<marketContent>().objid;
            }
        }*/
    }

    public void SagaGit()// bu kod patladı
    {
        AnaMenuSesManager.instance.ClickSesCal();
        int objnum=objenumarası;
        
        
        if (objnum < MarketObjeleri.Length - 1)
        {
           
            MarketObjeleri[objnum].gameObject.SetActive(false);
            objnum++;
            MarketObjeleri[objnum].gameObject.transform.DOMoveX(0, .3f).SetEase(Ease.InOutBack).From();
            MarketObjeleri[objnum].gameObject.SetActive(true);

            objenumarası = objnum;
            Debug.Log(" OBJE NUMARASI  :" + objenumarası);
        }
    }

    public void SolaGit()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        int objnum = objenumarası;

        if (objnum > 0)
        {
            
            MarketObjeleri[objnum].gameObject.SetActive(false);
            objnum--;
            MarketObjeleri[objnum ].gameObject.transform.DOMoveX(0, .3f).SetEase(Ease.InOutBack).From();
            MarketObjeleri[objnum].gameObject.SetActive(true);
            objenumarası = objnum;
            Debug.Log(" OBJE NUMARASI  :" + objenumarası);
        }
    }
}
