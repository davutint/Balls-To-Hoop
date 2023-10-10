using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sure;
    [SerializeField] private int BaslangıcSuresi;
    [SerializeField] private GameManager gameManager;
    int tmp;
    private void Start()
    {
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
                gameObject.SetActive(false);
                BaslangıcSuresi = tmp;
               
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Top"))
        {
            gameManager.PotaBüyüt();
            gameObject.SetActive(false);
        }
    }
}
