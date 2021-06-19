using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShaderController : MonoBehaviour
{
    [SerializeField] bool enableDissolve;
    public UnityEvent OnBuildingFinish;
    Material material;
    float fade = 1;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        OnBuildingFinish = new UnityEvent();
    }

    public void SetDissolve()
    {
        float rand = Random.Range(0.05f, 0.1f);
        fade -= rand;
        material.SetFloat("_Fade", fade);
        BGMManager.instance.PlayAudioEffect("Bubble");

        if(fade <=0)
        {
            OnBuildingFinish.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Virus"))
        {
            if(enableDissolve)
                SetDissolve();

            Destroy(collision.gameObject);
        }
    }
}
