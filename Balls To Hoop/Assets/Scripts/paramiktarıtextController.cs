using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class paramiktarıtextController : MonoBehaviour
{
    Vector3 hedef;
    Vector3 scaleHedef;
   
    private void Start()
    {
        
        scaleHedef = new Vector3(0, 0, 0);
        hedef = new Vector3(transform.localPosition.x + (Random.Range(0, .7f)), transform.localPosition.y + (Random.Range(0, .7f)) , 0);
        this.transform.DOLocalMove(hedef, 2f);
        this.transform.DOScale(scaleHedef, 2.5f);
        StartCoroutine(bekle());
        Destroy(this.gameObject,3f);

    }

    public IEnumerator bekle()
    {
        yield return new WaitForSeconds(2.6f);
        DOTween.Kill(transform);
       
    }
}
