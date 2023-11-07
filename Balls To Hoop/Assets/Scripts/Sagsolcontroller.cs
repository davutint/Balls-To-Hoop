using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagsolcontroller : MonoBehaviour
{
    public GameObject Sag;
    public GameObject Sol;

    private void Start()
    {
        InvokeRepeating(nameof(SagSolDegis), 0, 5f);

    }
    void SagSolDegis()
    {
        if (!Sag.activeSelf)
        {
            Sol.SetActive(false);
            Sag.SetActive(true);

        }
        else
        {
            Sag.SetActive(false);
            Sol.SetActive(true);
        }


    }


}
