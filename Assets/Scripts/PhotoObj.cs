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
        Dialog,
        Disapera,
        Reset,
        Over
    }
    private TutorialStep mStep = TutorialStep.None;
    private Transform mPhoto;
    private Transform mKey;
    private bool mStartNextStep = false;
    private Flowchart mFlowChat;

    
    private BoxCollider mBox;

    private bool mIsGetKey = false;

    
    //private BoxCollider2D mKeyBox;
    public override void Init()
    {
        mPhoto = transform.Find("Photo");
        mKey = transform.Find("Key");
        mFlowChat = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        mBox = GetComponent<BoxCollider>();
        //mKeyBox = mKey.GetComponent<BoxCollider2D>();
        
    }
    
    public override void OnObjMouseDown()
    {
        mStep++;
        mBox.enabled = false;
        Debug.LogError(mStep);
        mStartNextStep = true;
    }
    
    public override void OnObjMouseUp()
    {

    }
    public override void OnUpdate()
    {
        if(mStep == TutorialStep.Over)
        {
            return;
        }
        if(mStartNextStep)
        {
            mStartNextStep = false;
            if(mStep == TutorialStep.Forcus)
            {
                mBox.enabled = false;
                ExcuteView("ViewPhoto");
            }
            else if(mStep == TutorialStep.Disapera)
            {
                mPhoto.gameObject.SetActive(false);
                mBox.enabled = true;
                
            }
            else if(mStep == TutorialStep.Reset)
            {
                mKey.gameObject.SetActive(false);
                mIsGetKey = true;
            }
        }
        if(mStep == TutorialStep.Forcus)
        {
            if(mIsViewing)
            {
                mBox.enabled = false;
            }
            else
            {
                OnViewOver();
                mStep = TutorialStep.Dialog;
            }
        }
        if(mStep == TutorialStep.Dialog)
        {
            if(mIsDialoging)
            {
                mBox.enabled = false;
            }
            else
            {
                mBox.enabled = true;
            }
        }
        if(mIsGetKey)
        {
            Debug.LogError("获得钥匙");
            mStep = TutorialStep.Over;
            mBox.enabled = false;
            ExitView();
        }
    }

    private void OnViewOver()
    {
        ExcuteSayDialog("LookPicture");
    }
    private void ForcusStep()
    {

    }

    public override void Play()
    {

    }
}
