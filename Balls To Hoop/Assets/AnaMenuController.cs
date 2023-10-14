using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * .5f);// skyboxu hareket ettiriyoruz;
    }


}
