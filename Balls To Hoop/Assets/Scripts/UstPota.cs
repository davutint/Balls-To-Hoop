using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UstPota : MonoBehaviour
{
    public GameObject PotaControl;
    public GameObject PatlamaEfektiObj;
    private void OnTriggerEnter(Collider other)
    {
        PotaControl.SetActive(false);
        GameObject tmp = Instantiate(PatlamaEfektiObj, transform.position, Quaternion.identity);
        ParticleSystem tmpparty = tmp.GetComponent<ParticleSystem>();
        float tm = tmpparty.main.duration;
        Destroy(tmp, tm);
    }
    private void OnTriggerExit(Collider other)
    {
        PotaControl.SetActive(true);
    }
}
