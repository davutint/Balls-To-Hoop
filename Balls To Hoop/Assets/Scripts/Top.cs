using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager _Gamemanager;

    Rigidbody rb;
    int para;
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
            _Gamemanager.Basket();
            SoundManager.instance.PotayaGırısCal();
        }
        else if (other.CompareTag("oyunbitti"))
        {
            _Gamemanager.Kaybettin();
        }

        if (other.CompareTag("Para"))
        {
            other.GetComponent<paraScript>().killtween();
            Destroy(other.gameObject);
            para += 10;
            UIController.instance.ParaText(para);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.instance.SekmeSesCal();
    }
}
