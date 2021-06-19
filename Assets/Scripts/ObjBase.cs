using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBase : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }
    public virtual void Init()
    { }
    public virtual void Play()
    { }
}
