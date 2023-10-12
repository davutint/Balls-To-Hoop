using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class paraScript : MonoBehaviour
{
    Vector3 poz = new Vector3(0, 180, 0);
    public GameObject party;
    public GameObject ElmasTextObj;
    void Start()
    {
        this.transform.DORotate(poz, 1).SetLoops(-1, LoopType.Incremental);
        StartCoroutine(bekle());
        Destroy(gameObject, 4f);

    }

    public IEnumerator bekle()
    {
        yield return new WaitForSeconds(3.8f);
        DOTween.Kill(transform);

    }

    public void ElmasTextSpawn()
    {
        Vector3 poz = new Vector3(transform.position.x + .3f, transform.position.y + .5f, 0);
        Instantiate(ElmasTextObj, poz, Quaternion.identity);
    }

    public void ElmasEfektOynat()
    {
       GameObject tmp= Instantiate(party, transform.position, Quaternion.identity);
        Destroy(tmp, .9f);
    }

    public void killtween()
    {
        DOTween.Kill(transform);
    }
}
