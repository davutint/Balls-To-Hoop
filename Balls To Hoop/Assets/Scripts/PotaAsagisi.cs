using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotaAsagisi : MonoBehaviour
{
    public GameObject PotaControl;
    private void OnTriggerEnter(Collider other)
    {
        PotaControl.SetActive(false);
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        PotaControl.SetActive(true);
        
    }
}
