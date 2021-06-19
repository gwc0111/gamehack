using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
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
    
    private BoxCollider mBox;

    private bool mIsGetKey = false;
    private bool mIsTweeing = false;
    public float TweenDur = 2f;
    //private BoxCollider2D mKeyBox;
    public override void Init()
    {
        mPhoto = transform.Find("Photo");
        mKey = transform.Find("Key");
        mBox = GetComponent<BoxCollider>();
        //mKeyBox = mKey.GetComponent<BoxCollider2D>();
        
    }
    
    public override void OnObjMouseDown()
    {
        if(mIsTweeing)
        {
            return;
        }
        mStep++;
        mBox.enabled = false;
        Debug.LogError(mStep);
        mStartNextStep = true;
    }
    public override void OnUpdate()
    {
        if(mIsTweeing)
        {
            return;
        }
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
                //mPhoto.gameObject.SetActive(false);
                mPhoto.DOLocalMoveX(15, TweenDur).OnComplete(()=> { mIsTweeing = false; });
                mPhoto.GetComponent<SpriteRenderer>().material.DOFade(0, TweenDur);
                mIsTweeing = true;
                mBox.enabled = true;
                
            }
            else if(mStep == TutorialStep.Reset)
            {
                //mKey.gameObject.SetActive(false);
                mIsGetKey = true;
                ShowKey();
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
            GameLogicManager.Instance.IsFirstLevelOver = mIsGetKey;
        }
    }
    private float dis = 0.5f;
    private void ShowKey()
    {

        mKey.DOScale(new Vector3(2, 2, 0), dis).OnComplete(() => {
            mKey.GetComponent<SpriteRenderer>().material.DOFade(0, dis).OnComplete(()=> {
                mKey.gameObject.SetActive(false);
            
            });
            
        });
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
