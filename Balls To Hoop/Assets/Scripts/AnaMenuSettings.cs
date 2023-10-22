using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AnaMenuSettings : MonoBehaviour
{
    float oyunsesi, efekt;
    [Header("----Ses Sliderlar")]
    public Slider oyunSesSlider, EfektSesSlider;

    public GameObject SettingsPanel;
    public TextMeshProUGUI MevcutParaText;

    public static AnaMenuSettings instance;
    private void Awake()
    {
        instance = this;
        PlayerPrefsAl();
    }
    private void Start()
    {

        MevcutParaText.text = PlayerPrefs.GetInt("Para").ToString()+" $";
        SliderDegeriniAyarla();
        Debug.Log("Efekt playerprefs Değeri  "+PlayerPrefs.GetFloat("Efekt"));
        Debug.Log("OyunSesi playerprefs Değeri  " + PlayerPrefs.GetFloat("OyunSesi"));

    }

    public void BackToMenu()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        oyunsesi = oyunSesSlider.value;//slider valueları floatın değeri oluyor

        efekt = EfektSesSlider.value;//aşagıda bu değerleri playerprefs yapıp oyun sahnesinde erişilebilir yapmış olacağız
        SettingsPanel.transform.DOMoveX(-2000, 1).SetEase(Ease.InOutBack);
        PlayerPrefsYap();
    }
    private void PlayerPrefsYap()
    {
        PlayerPrefs.SetFloat("Efekt", efekt);
        PlayerPrefs.SetFloat("OyunSesi", oyunsesi);
    }


    public void OpenSettingsMenu()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        SettingsPanel.transform.DOLocalMoveX(0, 1).SetEase(Ease.InOutBack);
    }
    public void PlayerPrefsAl()//varolan playerprefsi alacak
    {
        
        if (!PlayerPrefs.HasKey("Efekt"))
        {
            efekt = 1;
            Debug.Log("Daha Önce Atanmadığı için Değeri 1 oldu Efekt Sesi");

        }
        if (!PlayerPrefs.HasKey("OyunSesi"))
        {
            oyunsesi = 1;
            Debug.Log("Daha Önce Atanmadığı için Değeri 1 oldu Oyun Sesi");

        }
        efekt = PlayerPrefs.GetFloat("Efekt");
        oyunsesi = PlayerPrefs.GetFloat("OyunSesi");

    }

    public void SliderDegeriniAyarla()
    {
        oyunSesSlider.value = oyunsesi;//bunarı silip settings butonunu fonksiyonuna yaz
        EfektSesSlider.value = efekt;
    }

}
