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

    private GameObject mSayDiolog = null;
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
                StartCoroutine(WaitOver());
                
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
        if(mIsGetKey)
        {

        }
    }

    private IEnumerator WaitOver()
    {
        
        yield return new WaitForSeconds(1);
        mFlowChat.ExecuteBlock("LookPicture");
        mSayDiolog = GameObject.Find("SayDialog");
        yield return new WaitUntil(() => {
            return mSayDiolog.activeSelf == false; });
        mBox.enabled = true;
    }
    private void ForcusStep()
    {

    }

    public override void Play()
    {

    }
}
