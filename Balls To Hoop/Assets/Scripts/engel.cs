using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class engel : MonoBehaviour
{
    [SerializeField] private GameObject[] xSpawnNoktaları;
    [SerializeField] private GameObject[] ySpawnNoktaları;
    Vector3 baslangicPoz;
    [SerializeField]private Vector3 eksibaslangicPoz;


    [SerializeField] private float waitTime;
    float timer = 0;
    
    private void Start()
    {
        baslangicPoz = transform.position;
        
    }


    private void Update()
    {
        if (GameManager.instance.oyunBasladı)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                EngelGetir();
                StartCoroutine(bekle());
                timer = 0;

            }
        }
        
    }


    IEnumerator bekle()
    {
        yield return new WaitForSeconds(3f);
        EngelGotur();
    }

    

    public void EngelGetir()
    {
        float x = Random.Range(xSpawnNoktaları[0].transform.position.x, xSpawnNoktaları[1].transform.position.x);
        float y = Random.Range(ySpawnNoktaları[0].transform.position.y, xSpawnNoktaları[1].transform.position.x);
        float z = transform.position.z;
        Vector3 poz = new Vector3(x, y, z);
        transform.DOMove(poz, .4f);
    }

    public void EngelGotur()
    {
            transform.DOMove(baslangicPoz, .4f);
        
    }

    private void OnCollisionEnter(Collision collision)// Balkabağı topunu burada parçalıyoruz
    {
        if (collision.gameObject.tag == "Top")
        {
            collision.gameObject.GetComponent<Top>().PumpkinParcala();
            StartCoroutine(GameManager.instance.KaybetmeyiBeklet());
        }
    }
    

}
