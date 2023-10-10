using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGuc : MonoBehaviour
{
    [SerializeField]private float acı;
    [SerializeField] private float Uygulanacakguc;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(acı, 90, 0) * Uygulanacakguc, ForceMode.Force);
    }
}
