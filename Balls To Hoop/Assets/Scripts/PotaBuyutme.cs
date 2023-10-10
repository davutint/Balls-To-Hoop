using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sure;
    [SerializeField] private int BaslangıcSuresi;
    private GameManager gameManager;
    int tmp;
    private void Start()
    {
        gameManager= GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        tmp = BaslangıcSuresi;
        StartCoroutine(SayacBaslasın());
    }

    

    IEnumerator SayacBaslasın()//bu objeyi instantiate etmek gerekiyor
    {
        sure.text = BaslangıcSuresi.ToString();

        while (true)
        {
            yield return new WaitForSeconds(1f);
            BaslangıcSuresi--;
            sure.text = BaslangıcSuresi.ToString();
            if (BaslangıcSuresi==0)
            {
                Destroy(gameObject);
                BaslangıcSuresi = tmp;
               
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Top"))
        {
            gameManager.PotaBüyüt();
            Destroy(gameObject);
        }
    }
}
