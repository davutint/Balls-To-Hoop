using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource Sekme;
    public AudioSource PotayaGırıs;
    public AudioSource OyunSesi;
    public AudioSource ParaTopla;
    public AudioSource Nice;
    public AudioSource ButtonClick;


    private void Awake()
    {
        instance = this;

        //UIController.instance.SesAyarla();
    }


    public void ButtonClickSesCal()
    {
        ButtonClick.Play();
    }
    public void SekmeSesCal()
    {
        float rnd = Random.Range(.6f, 1f);
        Sekme.pitch = rnd;
        Sekme.Play();
        
    }


    

    public void PotayaGırısCal()
    {
        float rnd = Random.Range(.5f, 1f);
        PotayaGırıs.pitch = rnd;
        PotayaGırıs.Play();
    }

    public void ParaToplaCal()
    {
        
        ParaTopla.Play();
    }

    public void NiceSesCal()
    {

        Nice.Play();
    }
}
