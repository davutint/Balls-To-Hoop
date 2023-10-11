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
    public GameObject Top;
    Rigidbody toprb;
    public float Uygulanacakguc;

    public UIController uIController;
    public static GameManager instance;
    public bool oyunBasladı = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
        toprb = Top.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * .5f);// skyboxu hareket ettiriyoruz;
        if (oyunBasladı)
        {




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
        if (BasketSayısı== 5)
        {
            Engeller[0].SetActive(true);
        }
        else if(BasketSayısı == 15)
        {
            Engeller[1].SetActive(true);
        }
        else if (BasketSayısı == 30)
        {
            Engeller[2].SetActive(true);
        }
        else if (BasketSayısı == 60)
        {
            Engeller[2].SetActive(true);
        }
    }

    void TopMateryaliKontrol()
    {
        //playerpref kontrolü ile  topun satın alınmış materyali tespit edilecek;
    }
}
