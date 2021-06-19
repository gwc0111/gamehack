using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VirusBackground : MonoBehaviour
{
    float interval;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(0.5f, 2f);
        scale = Random.Range(0.5f, 1.2f);
        StartCoroutine(StartBreath());
    }

    IEnumerator StartBreath()
    {
        while(true)
        {
            transform.DOScale(scale, interval);
            yield return new WaitForSeconds(interval);

            transform.DOScale(1f, interval);
            yield return new WaitForSeconds(interval);
        }

    }
}
