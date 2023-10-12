using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("-----UI  OBJELERİ")]
    [SerializeField] private TextMeshProUGUI basketSayısıText;

    [Header("-----LEVEL TEMEL OBJELERİ")]
    [SerializeField] private GameObject Pota;
    [SerializeField]private GameObject platform;
    [SerializeField]private GameObject potaBuyutmeyetenk;
    [SerializeField] private GameObject[] xSpawnNoktaları;
    [SerializeField] private GameObject[] ySpawnNoktaları;
    [SerializeField] private GameObject[] Engeller;


    [Header("-----TOP OBJELERİ")]
    [SerializeField] private Material[] topMateryalleri;


    int BasketSayısı;
    private GameObject Top;
    Rigidbody toprb;
    public float Uygulanacakguc;

    public UIController uIController;
    public static GameManager instance;
    public bool oyunBasladı = false;
    float timer = 0;

    [SerializeField] private float nesneSpawnSuresi1, nesneSpawnSuresi2;
    private float waitTime;
    public GameObject[] Elmaslar;
    private void Awake()
    {
        instance = this;
        Top = GameObject.FindGameObjectWithTag("LavaBall");
    }
    private void Start()
    {
       
        toprb = Top.GetComponent<Rigidbody>();
        waitTime = Random.Range(nesneSpawnSuresi1, nesneSpawnSuresi2);
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

    public void Basket()
    {
        BasketSayısı++;
        uIController.BasketText(BasketSayısı);
        PotaDegıs();

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
    }

    public void PotaBüyüt()
    {
        Pota.transform.localScale = new Vector3(55, 55, 55);
    }

    

    public void OyunBasladı()
    {
        oyunBasladı = true;
        Top.GetComponent<Top>().gameObject.GetComponent<Rigidbody>().useGravity = true;
        uIController.TapToStartButonu.SetActive(false);
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

    void TopMateryaliKontrol()
    {
        //playerpref kontrolü ile  topun satın alınmış materyali tespit edilecek;
    }
}
