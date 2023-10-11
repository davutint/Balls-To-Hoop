using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject TapToStartButonu;
    public TextMeshProUGUI _ParaText;
    public TextMeshProUGUI BasketSayısıText;

    public void AnaMenuDon()
    {
        //Oyun sonu ekranında anamenuye dön menusü
    }

    public void OyundanCık()
    {
        //Exit butonu
    }
    public void BasketText(int basket)
    {
        BasketSayısıText.text = basket.ToString();
    }
    public void ParaText(int para)
    {
        _ParaText.text = para.ToString();
    }

}
