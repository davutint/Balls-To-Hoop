using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;


    public GameObject TapToStartButonu;
    public GameObject GameIntroductionobj;
    [Header("-----SLIDER  OBJELERİ")]
    public Slider AnaSesSlider;
    public Slider EfektSesSlider;

    [Header("-----GAMEOVER VE PAUSEMENU  OBJELERİ")]
    public GameObject PauseMenuPanel;
    public GameObject GameOverMenuPanel;


    [Header("-----TEXTMESHPRO  OBJELERİ")]
    public TextMeshProUGUI _ParaText;
    public TextMeshProUGUI BasketSayısıText;
    public TextMeshProUGUI yüksekSkoreText;
    public TextMeshProUGUI oyunSonuKazanılan;

    [Header("-----BASLANGICANİMASYONPANELİ  OBJELERİ")]
    public Image baslangicAnimasyonPaneli;
    float oyunsesi, efektsesi;
    private void Awake()
    {
        instance = this;



    }

    private void Start()
    {

        BaslangıcSesDegerleriniCek();
        Time.timeScale = 1;
        baslangicAnimasyonPaneli.DOFade(0, 1f);
        Debug.Log("Efekt playerprefs Değeri Oyun Sahnesi " + PlayerPrefs.GetFloat("Efekt"));
        Debug.Log("OyunSesi playerprefs Değeri Oyun Sahnesi " + PlayerPrefs.GetFloat("OyunSesi"));
        SesAyarla();
    }



    public void AnaMenuyeDon()
    {
        SoundManager.instance.ButtonClickSesCal();
        SesAyarla();
        SceneManager.LoadScene(0);

    }



    public void BaslangıcSesDegerleriniCek()
    {
        efektsesi = PlayerPrefs.GetFloat("Efekt");

        oyunsesi = PlayerPrefs.GetFloat("OyunSesi");

        AnaSesSlider.value = oyunsesi;
        EfektSesSlider.value = efektsesi;


    }

    public void SesAyarla()//bunları playerprefs olarak ayarla sonra ana menuden çek/hem baslangıçta hem ayarladıktan sonra güncelle
    {

        SoundManager.instance.OyunSesi.volume = AnaSesSlider.value;//su anki slider degeri ses degerine esit
        SoundManager.instance.Sekme.volume = EfektSesSlider.value;
        SoundManager.instance.PotayaGırıs.volume = EfektSesSlider.value;
        SoundManager.instance.Nice.volume = EfektSesSlider.value;

        oyunsesi = AnaSesSlider.value;
        efektsesi = EfektSesSlider.value;
        SesPlayerPrefsYap();
    }

    public void SesPlayerPrefsYap()
    {
        PlayerPrefs.SetFloat("Efekt", efektsesi);
        PlayerPrefs.SetFloat("OyunSesi", oyunsesi);
    }


    public void GameIntroductionobjAc()
    {
        GameIntroductionobj.SetActive(true);
    }

    #region Butonlar

    public void GameIntroductionobjKapat()
    {
        SoundManager.instance.ButtonClickSesCal();
        GameIntroductionobj.SetActive(false);
    }


    public void PauseMenuAc()
    {
        SoundManager.instance.ButtonClickSesCal();
        AnaSesSlider.value = oyunsesi;
        EfektSesSlider.value = efektsesi;
        PauseMenuPanel.transform.DOLocalMoveX(0, 0);
        PauseMenuPanel.SetActive(true);//dotween ile sahne dışına götür
        Time.timeScale = 0;
        GameManager.instance.oyunBasladı = false;
    }

    public void OyunaDon()
    {
        SoundManager.instance.ButtonClickSesCal();
        SesAyarla();
        //PauseMenuPanel.SetActive(false);//dotween ile hareket ettir sahneye çağır
        PauseMenuPanel.transform.DOLocalMoveX(2000, .4f).SetEase(Ease.InOutBack);
        Time.timeScale = 1;
        GameManager.instance.oyunBasladı = true;
    }

    public void GameOverMenuGetir()
    {
        GameOverMenuPanel.SetActive(true);
        GameOverMenuPanel.transform.DOLocalMoveX(0, .5f).SetEase(Ease.InOutBack);
    }
    public void GameOverMenuGotur()
    {
        GameOverMenuPanel.SetActive(false);
        GameOverMenuPanel.transform.DOLocalMoveX(-1400, .3f).SetEase(Ease.InOutBack);

    }

    public void QuitGame()
    {
        SoundManager.instance.ButtonClickSesCal();
        Application.Quit();
    }



    public void RestartGame()
    {
        SoundManager.instance.ButtonClickSesCal();
        SceneManager.LoadScene(1);
    }
    #endregion

    #region TextRegion

    public void ParaText(int _Para)
    {

        _ParaText.text = _Para.ToString();
    }

    public void BasketText(int basket)
    {

        BasketSayısıText.text = basket.ToString();


    }


    public void BaslangıcParaText()
    {
        _ParaText.text = PlayerPrefs.GetInt("Para").ToString();
    }

    public void OyunSonuKazanılanParaText()
    {
        oyunSonuKazanılan.text = "+" + GameManager.instance.ParaKazanmaMiktarı().ToString() + " $";
    }

    public void YüksekSkoreTextGuncelle(int yeniskore)
    {
        yüksekSkoreText.text = yeniskore.ToString();
    }

    #endregion
}
