using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("-----UI OBJELERİ")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtılmasıGerekenTop;

    [Header("-----LEVEL TEMEL OBJELERİ")]
    [SerializeField] private GameObject Pota;
    [SerializeField]private GameObject platform;
    [SerializeField]private GameObject potaBuyutmeyetenk;
    [SerializeField] private GameObject[] xSpawnNoktaları;
    [SerializeField] private GameObject[] ySpawnNoktaları;
    int BasketSayısı;   

    private void Start()
    {
        for(int i = 0; i < AtılmasıGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }
        InvokeRepeating("ozellikOlussun", 3f,6f);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
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
            
        }
    }

    public void Basket()
    {
        BasketSayısı++;
        GorevGorselleri[BasketSayısı - 1].sprite = GorevTamamSprite;

        if (BasketSayısı==AtılmasıGerekenTop)
        {
            Debug.Log("KAZANDIN");
        }
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
        float y = Random.Range(ySpawnNoktaları[0].transform.position.y, ySpawnNoktaları[1].transform.position.y);
        potaBuyutmeyetenk.transform.position = new Vector3(x, y, potaBuyutmeyetenk.transform.position.z);
        potaBuyutmeyetenk.SetActive(true);
    }
}
