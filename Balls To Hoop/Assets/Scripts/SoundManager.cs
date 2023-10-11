using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource Sekme;
    public AudioSource PotayaGırıs;
    public AudioSource OyunSesi;


    private void Awake()
    {
        instance = this;
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
}
