using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    Material material;
    float fade = 1;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    //图像完整是1，图像完全消失是0
    public void SetDissolve(float fade)
    {
        material.SetFloat("_Fade", fade);
    }
}
