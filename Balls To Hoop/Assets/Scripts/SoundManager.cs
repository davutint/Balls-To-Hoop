using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource Sekme;
    [SerializeField] private AudioSource PotayaGırıs;


    private void Awake()
    {
        instance = this;
    }

    public void SekmeSesCal()
    {
        float rnd = Random.Range(.5f, 1);
        Sekme.pitch = 2;
        Sekme.Play();
        
    }

    public void PotayaGırısCal()
    {
        PotayaGırıs.Play();
    }
}
