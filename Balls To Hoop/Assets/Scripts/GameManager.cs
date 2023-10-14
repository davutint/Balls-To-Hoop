using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    [Header("-----UI  OBJELERİ")]
    [SerializeField] private TextMeshProUGUI basketSayısıText;
    public GameObject GameOverPanel;

    [Header("-----LEVEL TEMEL OBJELERİ")]
    [SerializeField] private GameObject Pota;
    [SerializeField]private GameObject platform;
    [SerializeField]private GameObject potaBuyutmeyetenk;
    [SerializeField] private GameObject[] xSpawnNoktaları;
    [SerializeField] private GameObject[] ySpawnNoktaları;
    [SerializeField] private GameObject[] Engeller;


    [Header("-----TOP OBJELERİ")]
    [SerializeField] private Material[] topMateryalleri;
    public GameObject LavaBall, NormalBall;

    int BasketSayısı;
    private GameObject Top;
    Rigidbody toprb;
    public float Uygulanacakguc;

    
    public static GameManager instance;
    public bool oyunBasladı = false;
    float timer = 0;

    [SerializeField] private float nesneSpawnSuresi1, nesneSpawnSuresi2;
    private float waitTime;
    public GameObject[] Elmaslar;
    public GameObject NiceEfektObj;
    public int yüksekSkore;
    public int Para;
    Top topScript;

    int topType;

    private void Awake()
    {
        topType = PlayerPrefs.GetInt("SeçilenTop");

        switch (topType)
        {
            case 0:
                NormalBall.SetActive(true);
                break;
            case 1:
                LavaBall.SetActive(true);
                break;
            default:
                NormalBall.SetActive(true);
                break;
        }

        instance = this;
        Top = GameObject.FindGameObjectWithTag("Top");
        yüksekSkore = PlayerPrefs.GetInt("yüksekSkore",0);
        Para= PlayerPrefs.GetInt("Para", 0);
    }
    private void Start()
    {
        //yüksekskore texti güncelle bunun altına
        toprb = Top.GetComponent<Rigidbody>();
        topScript = Top.GetComponent<Top>();
        waitTime = Random.Range(nesneSpawnSuresi1, nesneSpawnSuresi2);
        UIController.instance.BaslangıcParaText();
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * .5f);// skyboxu hareket ettiriyoruz;
        if (oyunBasladı)
        {


            ParaSpawn();

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 mouseOnScreen = Camera.main.ScreenToWorldPoint(mousePos);

                if (mousePos.x < Screen.width / 2)
                {

                    //left -70
                    float solAcı = 45;
                    toprb.AddForce(new Vector3(solAcı, 90, 0) * Uygulanacakguc, ForceMode.Force);
                }
                else if (mousePos.x > Screen.width / 2)
                {
                    //right 70

                    float sagAcı = -45;
                    toprb.AddForce(new Vector3(sagAcı, 90, 0) * Uygulanacakguc, ForceMode.Force);
                }
                else
                {
                    toprb.AddForce(new Vector3(0, 90, 0) * Uygulanacakguc, ForceMode.Force);
                }



            }

            EngelAyarları();
        }

  
    }

    public void NiceSpawn(int basket)
    {
        if (basket % 2 == 0)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(1f, 2f);
            Vector3 poz = new Vector3(x, y, 0);
            GameObject tmp = Instantiate(NiceEfektObj, poz, Quaternion.identity);
            SoundManager.instance.NiceSesCal();
            BasketTextAnim();
            //Destroy(tmp, .9f);
        }
    }

    public void BasketTextAnim()
    {
        UIController.instance.BasketSayısıText.transform.DOShakeScale(1, 1, 5, 20);
    }

    void ParaSpawn()
    {
        
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            
            float x = Random.Range(xSpawnNoktaları[0].transform.position.x
                , ySpawnNoktaları[0].transform.position.y);

            float y = Random.Range(xSpawnNoktaları[0].transform.position.y
                , ySpawnNoktaları[0].transform.position.y);

            Vector3 poz = new Vector3(x, y, 0);

            int rdn = Random.Range(0, 3);

            Instantiate(Elmaslar[rdn], poz, Quaternion.identity);
            
            waitTime = Random.Range(nesneSpawnSuresi1, nesneSpawnSuresi2);
            timer = 0;
        }

    }

    public void Basket(int basketDegeri)
    {
       
        BasketSayısı+=Top.GetComponent<Top>().basketDegeri;
        UIController.instance.BasketText(BasketSayısı);
        NiceSpawn(BasketSayısı);
        PotaDegıs();
        int yeniYüksekScore = YeniYuksekSkoreTespit(BasketSayısı);

        UIController.instance.YüksekSkoreTextGuncelle(yeniYüksekScore);

    }

    public void PotaDegıs()
    {
        float x = Random.Range(xSpawnNoktaları[0].transform.position.x, xSpawnNoktaları[1].transform.position.x);
        float y = Random.Range(ySpawnNoktaları[0].transform.position.y, xSpawnNoktaları[1].transform.position.y);
        Pota.transform.position= new Vector3(x, y, potaBuyutmeyetenk.transform.position.z);
    }

    

    public void Kaybettin()
    {
        Debug.Log("KAYBETTİN");
        GameOverPanel.SetActive(true);
        oyunBasladı = false;
        Time.timeScale = 0;
        UIController.instance.OyunSonuKazanılanParaText();
    }

    public void PotaBüyüt()
    {
        Pota.transform.localScale = new Vector3(55, 55, 55);
    }

    

    public void OyunBasladı()
    {
        oyunBasladı = true;
        Top.GetComponent<Top>().gameObject.GetComponent<Rigidbody>().useGravity = true;
        UIController.instance.TapToStartButonu.SetActive(false);
    }

    void EngelAyarları()
    {
        if (BasketSayısı== 2)
        {
            Engeller[0].SetActive(true);
        }
        else if(BasketSayısı == 3)
        {
            Engeller[1].SetActive(true);
        }
        else if (BasketSayısı == 4)
        {
            Engeller[2].SetActive(true);
        }
        else if (BasketSayısı == 5)
        {
            Engeller[2].SetActive(true);
        }
    }

    public int ParaKazanmaMiktarı()
    {
        int para = Para;//oyun basında tuttuğun mevcut parayı oyun sonundaki para ile karşılaştır
        int oyunSonupara = PlayerPrefs.GetInt("Para");

        int kazanılanMiktar = Mathf.Abs(oyunSonupara - para);

        return kazanılanMiktar; //oyun sonu panelinde uıda yazacak kısım;
    }

    

    public int YeniYuksekSkoreTespit(int yeniSkor)
    {
        int yeniYüksekSkore;

        if (yeniSkor > yüksekSkore)
        {
            yüksekSkore = yeniSkor;
            PlayerPrefs.SetInt("yüksekSkore", yüksekSkore);
            yeniYüksekSkore = yüksekSkore;
            return yeniYüksekSkore;
            
        }
        else
            return yüksekSkore;

        
    }
    void TopMateryaliKontrol()
    {
        //playerpref kontrolü ile  topun satın alınmış materyali tespit edilecek;
    }
}
