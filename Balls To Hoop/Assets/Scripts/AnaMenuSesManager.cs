using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuSesManager : MonoBehaviour
{
    public static AnaMenuSesManager instance;
    public AudioSource ClickSes;
    private void Awake()
    {
        instance = this;
    }


    public void ClickSesCal()
    {
        ClickSes.Play();
    }
}
