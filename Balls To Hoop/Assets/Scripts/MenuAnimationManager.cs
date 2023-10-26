using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MenuAnimationManager : MonoBehaviour
{
    public Transform  PlayButton, QuitObj, MarketObj,SettingsObj,OyunIsmiObj,MevcutParaText;
    private int OyuncununParası;
    public GameObject LavaBall, NormalBall; //pumpkinball ekle
//    private string isLavaBallPurchased = "isLavaBallPurchased";
    private string SecılenTop = "SeçilenTop";
    public GameObject LavaSatınAlButonObj;
    public GameObject LavaSelectObj;
    public Image BaslangınAnim;
    int topType;
    public GameObject LavaSelectedBelirt;
    public GameObject NormalSelectedBelirt;
    //public GameObject PumpkinBallSelectedObj;

    private void Awake()
    {
        Time.timeScale = 1;
        MarketObjeleriSatınAlımKontrol();
        topType = PlayerPrefs.GetInt("SeçilenTop");//başlangıçta hangi topun anamenüde aktif olacağını kontrol ediyoruz

        switch (topType)//pumpkin seçeneği ekle
        {
            case 0:
                NormalBall.SetActive(true);
                NormalSelectedBelirt.SetActive(true);
                NormalSelectedBelirt.transform.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

                break;
            case 1:
                LavaBall.SetActive(true);
                LavaSelectedBelirt.SetActive(true);
                LavaSelectedBelirt.transform.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
                break;//case 2 pumpking eklenecek
            default:
                NormalBall.SetActive(true);
                break;
        }
    }
    private void Start()
    {

        
        OyuncununParası = PlayerPrefs.GetInt("Para");
        StartMenuAnimations();
        Debug.Log(OyuncununParası);


    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * .5f);// skyboxu hareket ettiriyoruz;
    }

    public void StartMenuAnimations()
    {
        // selected objeside playbutton ile aynı animasyonu yapacak
        PlayButton.DOScale(new Vector2(.87f, 1.23f), .55f).SetLoops(-1, LoopType.Yoyo);
        PlayButton.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

        OyunIsmiObj.DOMoveY(0,1).SetEase(Ease.InOutBack).From();
        MevcutParaText.DOMoveX(0, 1).SetEase(Ease.InOutBack).From();

        MarketObj.DOScale(new Vector2(.77f, 1.13f), .55f).SetLoops(-1, LoopType.Yoyo);
        MarketObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();


        SettingsObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        SettingsObj.DORotate(new Vector3(0, 0, 180), 5f).SetLoops(-1, LoopType.Incremental);
        QuitObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

    }

    public void LavaSatınAl(int ObjeDegeri)
    {
        AnaMenuSesManager.instance.ClickSesCal();
        string satınalındıMı = PlayerPrefs.GetString("isLavaBallPurchased");
        if (OyuncununParası>=ObjeDegeri)//oyuncu tekrar satın alamasın diye bir kontrol daha yap
        {
            if (satınalındıMı != "true")
            {
                OyuncununParası -= ObjeDegeri;
                PlayerPrefs.SetInt("Para", OyuncununParası);
                PlayerPrefs.SetString("isLavaBallPurchased", "true");//LavaBall Satın alındı ve birdaha alınamaz;
                MarketObjeleriSatınAlımKontrol();
                AnaMenuSettings.instance.MevcutParaText.text= PlayerPrefs.GetInt("Para").ToString() + " $";
                Debug.Log("Satın alma Gerçekleşti  " + OyuncununParası);
                Debug.Log(PlayerPrefs.GetString("isLavaBallPurchased"));
            }
            if (satınalındıMı=="true")
            {
                Debug.Log("ZATEN SATIN ALDIN");

            }


        }
        else
        {
            //Mevcut PAra objesini shakele
            MevcutParaText.DOShakePosition(1, 20, 20);
            Debug.Log("Paran yetmiyor");
        }
    }

    /*public void PumpkinSatınAl(int ObjeDegeri)// IAP ile alınabilir yapacağız.
    {
        //farklı bir scriptte ıap kurulumunu yap ve o scriptte bu fonksiyonu çağır, burayı ona göre modifiye et

        /*AnaMenuSesManager.instance.ClickSesCal();
        string satınalındıMı = PlayerPrefs.GetString("isLavaBallPurchased");
        if (OyuncununParası >= ObjeDegeri)//oyuncu tekrar satın alamasın diye bir kontrol daha yap
        {
            if (satınalındıMı != "true")
            {
                OyuncununParası -= ObjeDegeri;
                PlayerPrefs.SetInt("Para", OyuncununParası);
                PlayerPrefs.SetString("isLavaBallPurchased", "true");//LavaBall Satın alındı ve birdaha alınamaz;
                MarketObjeleriSatınAlımKontrol();
                AnaMenuSettings.instance.MevcutParaText.text = PlayerPrefs.GetInt("Para").ToString() + " $";
                Debug.Log("Satın alma Gerçekleşti  " + OyuncununParası);
                Debug.Log(PlayerPrefs.GetString("isLavaBallPurchased"));
            }
            if (satınalındıMı == "true")
            {
                Debug.Log("ZATEN SATIN ALDIN");

            }


        }
        else
        {
            //Mevcut PAra objesini shakele
            MevcutParaText.DOShakePosition(1, 20, 20);
            Debug.Log("Paran yetmiyor");
        }
    }*/

    public void QuitGame()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        Application.Quit();
    }

    public void PlayGame()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        if (LavaSelectedBelirt.activeSelf)
        {
            LavaSelectedBelirt.transform.DOLocalMoveX(2000, 1).SetEase(Ease.InOutBack);
        }
        if(NormalSelectedBelirt.activeSelf)
        {
            NormalSelectedBelirt.transform.DOLocalMoveX(2000, 1).SetEase(Ease.InOutBack);
        }
        OyunIsmiObj.DOLocalMoveY(2000,1).SetEase(Ease.InOutBack);
        MevcutParaText.DOLocalMoveX(2000, 1).SetEase(Ease.InOutBack);
        PlayButton.DOMoveX(-2000, 1f).SetEase(Ease.InOutBack);
        MarketObj.DOMoveX(2000, 1f).SetEase(Ease.InOutBack);
        QuitObj.DOMoveX(-2000, 1f).SetEase(Ease.InOutBack);
        SettingsObj.DORotate(new Vector3(0, 0, 180), .2f).SetLoops(-1, LoopType.Incremental);
        SettingsObj.DOMoveX(-2000, 1f).SetEase(Ease.InExpo).OnComplete(() =>
        {
            BaslangınAnim.DOFade(1, 1).OnComplete(() =>
            {
                DOTween.KillAll();

                SceneManager.LoadScene(1);//oyun sahnesi setting tamamlanınca yükleniyor;
            });
            
        });
    }



    public void LavaBallSelected()// Bunlar select butonuna atanacak;
    {
        AnaMenuSesManager.instance.ClickSesCal();
        //playerprefs balltype anahtar kelimesine 1 veya 2 atayarak oyun sahnesinden kontrol sağlayacağız;
        if (!LavaSelectedBelirt.activeSelf)
        {
            LavaSelectedBelirt.SetActive(true);
            LavaSelectedBelirt.transform.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        }

        if (LavaSelectedBelirt.transform.localPosition.x==0)
        {
            LavaSelectedBelirt.transform.DOShakePosition(1, 10, 10);
        }
        

        NormalSelectedBelirt.SetActive(false);
        //PumpkinBallSelectedObj.SetActive(false); pumpkin ekledikten sonra
        PlayerPrefs.SetInt(SecılenTop, 1);// oyun sahnesinden awakede bunu kontrol ederek if şartı ile topu aktif edeceğiz;
    }
    /*public void PumpkinBallSelected()// Bunlar select butonuna atanacak;
    {
        AnaMenuSesManager.instance.ClickSesCal();
        //playerprefs balltype anahtar kelimesine 1 veya 2 atayarak oyun sahnesinden kontrol sağlayacağız;
        if (!PumpkinBallSelectedObj.activeSelf)
        {
            PumpkinBallSelectedObj.SetActive(true);
            PumpkinBallSelectedObj.transform.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        }

        if (PumpkinBallSelectedObj.transform.localPosition.x == 0)
        {
            PumpkinBallSelectedObj.transform.DOShakePosition(1, 10, 10);
        }


        NormalSelectedBelirt.SetActive(false);
        LavaSelectedBelirt.SetActive(false);
        PlayerPrefs.SetInt(SecılenTop, 2);// oyun sahnesinden awakede bunu kontrol ederek if şartı ile topu aktif edeceğiz;
    }*/

    public void NormalBallSelected()
    {
        AnaMenuSesManager.instance.ClickSesCal();
        //playerprefs balltype anahtar kelimesine 1 veya 2 atayarak oyun sahnesinden kontrol sağlayacağız;
        if (!NormalSelectedBelirt.activeSelf)
        {
            NormalSelectedBelirt.SetActive(true);
            NormalSelectedBelirt.transform.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        }

        if (NormalSelectedBelirt.transform.localPosition.x==0)//if olmadan shake kodu yüzünden üstteki move animasyonu yarıda kesiliyor
        {
            NormalSelectedBelirt.transform.DOShakePosition(1, 10, 10);
        }
        
        
        LavaSelectedBelirt.SetActive(false);
        //PumpkinBallSelectedObj.SetActive(false);
        PlayerPrefs.SetInt(SecılenTop, 0);// oyun sahnesinden awakede bunu kontrol ederek if şartı ile topu aktif edeceğiz;
    }
    // Oyuncunun sahip olduğu satın alınan objeleri kontrol etme

    public void MarketObjeleriSatınAlımKontrol()//aynısını pumpkin için yap
    {
        Debug.Log(PlayerPrefs.GetString("isLavaBallPurchased"));

        
        if (PlayerPrefs.GetString("isLavaBallPurchased") == "true")
        {
            //satın alma butonu yerine select butonu gelecek;
            LavaSatınAlButonObj.SetActive(false);
            LavaSelectObj.SetActive(true);
        }

        if (PlayerPrefs.GetString("isPumpkinBallPurchased") == "true")//bunu pumpkin için kontrol et tekrar
        {
            //pumpkin için olanları yazacaksın buraya
            //satın alma butonu yerine select butonu gelecek;
            //LavaSatınAlButonObj.SetActive(false);
            //LavaSelectObj.SetActive(true);
        }
    }
    
    



}