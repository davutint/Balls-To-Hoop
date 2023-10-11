using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager _Gamemanager;

    Rigidbody rb;
    private void Start()
    {

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
    }
    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.instance.SekmeSesCal();
    }
}
