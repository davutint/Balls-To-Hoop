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
    int BasketSayısı;
    public GameObject Top;
    Rigidbody toprb;
    public float Uygulanacakguc;

    private void Start()
    {
        
        InvokeRepeating("ozellikOlussun", 3f,6f);

        toprb = Top.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseOnScreen = Camera.main.ScreenToWorldPoint(mousePos);
            
            if (mousePos.x<Screen.width/2)
            {
                Debug.Log("EKRANIN SOLUNDA__"+mousePos.x + "___ " + Screen.width/2);
                //left -70
                float solAcı = 50;
                toprb.AddForce(new Vector3(solAcı, 90, 0) * Uygulanacakguc, ForceMode.Force);
            }
            else if(mousePos.x>Screen.width / 2)
            {
                //right 70
                Debug.Log("EKRANIN SAĞINDA" + mousePos.x + "___ " + Screen.width/2);
                float sagAcı = -50;
                toprb.AddForce(new Vector3(sagAcı, 90, 0) * Uygulanacakguc, ForceMode.Force);
            }
            else
            {
                toprb.AddForce(new Vector3(0, 90, 0) * Uygulanacakguc, ForceMode.Force);
            }

            
            
        }

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (platform.transform.position.x>-1f)
            {
                platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(
                platform.transform.position.x - .3f,
                platform.transform.position.y,
                platform.transform.position.z), .050f);
            }
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (platform.transform.position.x < 1f)
            {
                platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(
                platform.transform.position.x + .3f,
                platform.transform.position.y,
                platform.transform.position.z), .050f);

            }
            
        }*/
    }

    public void Basket()
    {
        BasketSayısı++;
        basketSayısıText.text = BasketSayısı.ToString();
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

    void ozellikOlussun()
    {
        float x = Random.Range(xSpawnNoktaları[0].transform.position.x, xSpawnNoktaları[1].transform.position.x);
        float y = Random.Range(ySpawnNoktaları[0].transform.position.y, xSpawnNoktaları[1].transform.position.y);
        potaBuyutmeyetenk.transform.position = new Vector3(x, y, potaBuyutmeyetenk.transform.position.z);
        GameObject tmp = Instantiate(potaBuyutmeyetenk, potaBuyutmeyetenk.transform.position, Quaternion.identity);
        Destroy(tmp,5f);
    }
}
