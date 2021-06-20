using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    [SerializeField] Sprite img;
    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time % 2 < 1)
        {
            sp.sprite = img;
        }
        else
            sp.sprite = null;
    }
}
