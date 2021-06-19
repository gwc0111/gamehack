using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PhotoObj : ObjBase
{
    private Transform mPhoto;
    private Transform mKey;
    //private BoxCollider2D mPhotoBox;
    //private BoxCollider2D mKeyBox;
    public override void Init()
    {
        mPhoto = transform.Find("Photo");
        mKey = transform.Find("Key");
        //mPhotoBox = mPhoto.GetComponent<BoxCollider2D>();
        //mKeyBox = mKey.GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        
    }
    public override void Play()
    {

    }
}
