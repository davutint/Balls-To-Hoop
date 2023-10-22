using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    
    Rigidbody rb;
    int para;
    public int basketDegeri;
    SphereCollider sc;
    public Vector3 baslangıcpoz;
    private void Start()
    {
        baslangıcpoz = transform.position;
        para = PlayerPrefs.GetInt("Para");
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
    }

    public void YerCekimiAc()
    {
         
         rb.useGravity = true;
         rb.isKinematic = false;
        /*if (this.gameObject.name=="balkabagitop")
        {
            foreach (Rigidbody rig in gameObject.GetComponentsInChildren<Rigidbody>())
            {
                rig.useGravity = true;
            }
        }*/
        
    }

    public void PumpkinParcala()
    {
        if (gameObject.name=="balkabagitop")
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;

            gameObject.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("rb kodunu geçti");
            Debug.Log("rb kodunu geçti");
            Debug.Log("Pumpkin parçalamaya girdi");
            foreach (SphereCollider col in gameObject.GetComponentsInChildren<SphereCollider>())
            {
                if (col != null)
                {
                    col.enabled = true;

                }
                else
                    Debug.Log("Bu Top Balkabağı Topu Değil !");
                foreach (Rigidbody rig in gameObject.GetComponentsInChildren<Rigidbody>())
                {
                    rig.useGravity = true;
                    rig.isKinematic = false;
                }
            }
        }
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("basket"))
        {
            GameManager.instance.Basket(basketDegeri);
            SoundManager.instance.PotayaGırısCal();
        }
        else if (other.CompareTag("oyunbitti"))
        {
            GameManager.instance.Kaybettin();
        }

        if (other.CompareTag("mavielmas"))
        {
            other.GetComponent<paraScript>().ElmasEfektOynat();
            other.GetComponent<paraScript>().killtween();
            other.GetComponent<paraScript>().ElmasTextSpawn();
            Destroy(other.gameObject);
            para += 10;
            GameManager.instance.oyunSonupara += 10;
            SoundManager.instance.ParaToplaCal();
            UIController.instance.ParaText(para);
            ParaGuncelle();
        }
        if (other.CompareTag("yesilelmas"))
        {
            other.GetComponent<paraScript>().ElmasEfektOynat();
            other.GetComponent<paraScript>().killtween();
            other.GetComponent<paraScript>().ElmasTextSpawn();
            Destroy(other.gameObject);
            para += 20;
            GameManager.instance.oyunSonupara += 20;
            SoundManager.instance.ParaToplaCal();
            UIController.instance.ParaText(para);
            ParaGuncelle();
        }
        if (other.CompareTag("pembeelmas"))
        {
            other.GetComponent<paraScript>().ElmasEfektOynat();
            other.GetComponent<paraScript>().killtween();
            other.GetComponent<paraScript>().ElmasTextSpawn();
            Destroy(other.gameObject);
            para += 30;
            GameManager.instance.oyunSonupara += 30;
            SoundManager.instance.ParaToplaCal();
            UIController.instance.ParaText(para);
            ParaGuncelle();
        }
    }
    public void ParaGuncelle()
    {
        PlayerPrefs.SetInt("Para", para);
    }
    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.instance.SekmeSesCal();
    }

    
}
