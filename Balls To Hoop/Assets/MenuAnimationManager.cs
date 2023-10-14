using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnimationManager : MonoBehaviour
{
    public Transform  PlayButton, QuitObj, MarketObj,SettingsObj,OyunIsmiObj;
    private int OyuncununParası;
    
    private string isLavaBallPurchased = "isLavaBallPurchased";
    private string SecılenTop = "SeçilenTop";
    public GameObject LavaSatınAlButonObj;
    public GameObject LavaSelectObj;

    private void Awake()
    {
        MarketObjeleriSatınAlımKontrol();

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
        PlayButton.DOScale(new Vector2(.87f, 1.23f), .55f).SetLoops(-1, LoopType.Yoyo);
        PlayButton.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

        MarketObj.DOScale(new Vector2(.77f, 1.13f), .55f).SetLoops(-1, LoopType.Yoyo);
        MarketObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();


        SettingsObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();
        SettingsObj.DORotate(new Vector3(0, 0, 180), 5f).SetLoops(-1, LoopType.Incremental);
        QuitObj.DOMoveX(0, 1f).SetEase(Ease.InOutBack).From();

    }

    public void LavaSatınAl(int ObjeDegeri)
    {
        
        if (OyuncununParası>=ObjeDegeri)//oyuncu tekrar satın alamasın diye bir kontrol daha yap
        {
            OyuncununParası -= ObjeDegeri;
            PlayerPrefs.SetInt("Para", OyuncununParası);
            PlayerPrefs.SetString(isLavaBallPurchased,"true");//LavaBall Satın alındı ve birdaha alınamaz;
            MarketObjeleriSatınAlımKontrol();
            Debug.Log("Satın alma Gerçekleşti  "+OyuncununParası);
            Debug.Log(PlayerPrefs.GetString(isLavaBallPurchased));
            
        }
        else
        {
            Debug.Log("Paran yetmiyor");
        }
    }

    public void PlayGame()
    {
        OyunIsmiObj.DOLocalMoveY(2000,1).SetEase(Ease.InOutBack);
        SettingsObj.DORotate(new Vector3(0, 0, 180), .2f).SetLoops(-1, LoopType.Incremental);
        SettingsObj.DOMoveX(-2000, 1f).SetEase(Ease.InExpo);
        PlayButton.DOMoveX(-2000, 1f).SetEase(Ease.InOutBack);
        MarketObj.DOMoveX(-2000, 1f).SetEase(Ease.InOutBack);
        QuitObj.DOMoveX(-2000, 1f).SetEase(Ease.InOutBack);
    }



    public void LavaBallSelected()// Bunlar select butonuna atanacak;
    {
        //playerprefs balltype anahtar kelimesine 1 veya 2 atayarak oyun sahnesinden kontrol sağlayacağız;

        PlayerPrefs.SetInt(SecılenTop, 1);// oyun sahnesinden awakede bunu kontrol ederek if şartı ile topu aktif edeceğiz;
    }

    public void NormalBallSelected()
    {
        //playerprefs balltype anahtar kelimesine 1 veya 2 atayarak oyun sahnesinden kontrol sağlayacağız;

        PlayerPrefs.SetInt(SecılenTop, 0);// oyun sahnesinden awakede bunu kontrol ederek if şartı ile topu aktif edeceğiz;
    }
    // Oyuncunun sahip olduğu satın alınan objeleri kontrol etme

    public void MarketObjeleriSatınAlımKontrol()
    {
        Debug.Log(isLavaBallPurchased);

        
        if (PlayerPrefs.GetString(isLavaBallPurchased)== "true")
        {
            //satın alma butonu yerine select butonu gelecek;
            LavaSatınAlButonObj.SetActive(false);
            LavaSelectObj.SetActive(true);
        }

    }
    
    



}
public enum TopSecimi
{
    NormalBall,
    LavaBall,
}
