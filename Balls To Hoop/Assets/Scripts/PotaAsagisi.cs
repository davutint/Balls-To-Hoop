using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaAsagisi : MonoBehaviour
{
    public GameObject PotaControl;

    private void OnTriggerEnter(Collider other)
    {
        PotaControl.SetActive(false);

        Debug.Log("ÜST POTA OBJESİ KAPATILDI");
        
    }
    private void OnTriggerExit(Collider other)
    {
        PotaControl.SetActive(true);
        Debug.Log("ÜST POTA OBJESİ AÇILDI");
    }
}
