using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UstPota : MonoBehaviour
{
    public GameObject PotaControl;
    public ParticleSystem party;
    private void OnTriggerEnter(Collider other)
    {
        PotaControl.SetActive(false);
        party.Play();
       
    }
    private void OnTriggerExit(Collider other)
    {
        PotaControl.SetActive(true);
    }
}
