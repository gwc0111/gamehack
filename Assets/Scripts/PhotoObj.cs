using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
public class PhotoObj : ObjBase
{
    enum TutorialStep
    {
        None,
        Forcus,
        Disapera,
        Reset,
    }
    private TutorialStep mStep = TutorialStep.None;
    private Transform mPhoto;
    private Transform mKey;
    private bool mStartNextStep = false;
    private Flowchart mFlowChat;

    private bool mIsCanOperate = true;
    //private BoxCollider2D mPhotoBox;
    //private BoxCollider2D mKeyBox;
    public override void Init()
    {
        mPhoto = transform.Find("Photo");
        mKey = transform.Find("Key");
        mFlowChat = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        //mPhotoBox = mPhoto.GetComponent<BoxCollider2D>();
        //mKeyBox = mKey.GetComponent<BoxCollider2D>();
        
    }
    public override void OnObjMouseDown()
    {
        if(!mIsCanOperate)
        {
            return;
        }
        mStep = (TutorialStep)(mStep + 1);
        Debug.LogWarning("mStep : " + mStep);
        mStartNextStep = true;
    }
    
    public override void OnObjMouseUp()
    {
        mStartNextStep = false;
    }
    public override void OnUpdate(RaycastHit hit)
    {
        if(mStartNextStep)
        {
            mStartNextStep = false;
            if(mStep == TutorialStep.Forcus)
            {
                 mFlowChat.GetExecutingBlocks();
                mFlowChat.ExecuteBlock("ViewPhoto");
                StartCoroutine(WaitSeond());
            }
        }
    }

    private IEnumerator WaitSeond()
    {
        mIsCanOperate = false;
        yield return new WaitForSeconds(1);
        mIsCanOperate = true;
    }

    private void ForcusStep()
    {

    }

    public override void Play()
    {

    }
}
