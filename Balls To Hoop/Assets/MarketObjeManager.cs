using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketObjeManager : MonoBehaviour
{
    public GameObject[] MarketObjeleri;

    public void SagaGit(int objenumarası)// bu kod patladı
    {
        if (objenumarası < MarketObjeleri.Length - 1)
        {
            MarketObjeleri[objenumarası].gameObject.SetActive(false);
            MarketObjeleri[objenumarası + 1].gameObject.SetActive(true);
        }
    }

    public void SolaGit(int objenumarası)
    {
        if (objenumarası >= MarketObjeleri.Length - 1&&objenumarası>=0)
        {
            MarketObjeleri[objenumarası].gameObject.SetActive(false);
            MarketObjeleri[objenumarası - 1].gameObject.SetActive(true);
        }
    }
}
