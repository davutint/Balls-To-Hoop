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
    public Slider AnaSesSlider;
    public Slider EfektSesSlider;

    public GameObject PauseMenuPanel;
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }


    public void OyunaDon()
    {
        SesAyarla();
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.oyunBasladı = true;
    }
    public void PauseMenuAc()
    {
        AnaSesSlider.value = SoundManager.instance.OyunSesi.volume;
        EfektSesSlider.value = SoundManager.instance.Sekme.volume;
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.oyunBasladı = false;
    }



    public void SesAyarla()
    {
        SoundManager.instance.OyunSesi.volume = AnaSesSlider.value;
        SoundManager.instance.Sekme.volume = EfektSesSlider.value;
        SoundManager.instance.PotayaGırıs.volume = EfektSesSlider.value;

    }

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
