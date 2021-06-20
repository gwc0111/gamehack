using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    [SerializeField] Sprite img;
    public bool isEnable = false;
    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void SetEnable(bool b)
    {
        isEnable = b;
    }

    void Update()
    {
        if (!isEnable)
            return;

        if (Time.time % 2 < 1)
        {
            sp.sprite = img;
        }
        else
            sp.sprite = null;
    }
}
