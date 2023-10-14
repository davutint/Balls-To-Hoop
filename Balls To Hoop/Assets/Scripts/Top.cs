using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    
    Rigidbody rb;
    int para;
    public int basketDegeri;
    
    private void Start()
    {
        para = 0; //playerprefs ile alacağız daha sonra
        rb = GetComponent<Rigidbody>();
        
    }

    public void YerCekimiAc()
    {
        rb.useGravity = true;
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
