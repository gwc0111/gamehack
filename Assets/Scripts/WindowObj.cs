using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindowObj : ObjBase
{
    enum StepWindow
    {

    }
    private GameObject mLeftOpen;
    private GameObject mLeftClose;
    private GameObject mRightOpen;
    private GameObject mRightClose;
    public GameObject CurHitObj;
    private BoxCollider mBoxColl;
    bool mIsLeftOpening = false;
    bool mIsRightOpening = false;
    private BoxCollider mNoodleBox;

    private bool mIsDia = false;
    private bool mIsOver = false;
    public override void Init()
    {
        mLeftOpen = transform.Find("LeftOpen").gameObject;
        mLeftClose = transform.Find("LeftClose").gameObject;
        mRightClose = transform.Find("RightClose").gameObject;
        mRightOpen = transform.Find("RightOpen").gameObject;
        mBoxColl = GetComponent<BoxCollider>();
        mNoodleBox = GameObject.Find("NoodleBox").GetComponent<BoxCollider>();
        mNoodleBox.enabled = false;
    }
    public override void OnObjMouseEnter()
    {

    }
    public override void OnObjMouseDown()
    {
        Debug.LogError("down");
    }
    public override void OnUpdate()
    {
        if(mIsTweening)
        {
            return;
        }
        if(mIsOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitView();
        }
        if(mNoodleBox.enabled == false )
        {
            if(mIsLeftOpening && mIsRightOpening)
                mNoodleBox.enabled = true;
        }
        if(mIsDia)
        {
            if(!mIsDialoging)
            {
                ExitView();
                mNoodleBox.enabled = false;
                mIsOver = true;
            }
        }
    }
    public override void OnUpdateWithHit(RaycastHit hit, bool isMouseLeftDown)
    {
        if(mIsViewing)
        {
            return;
        }
        if(mIsTweening)
        {
            return;
        }
        if(mIsOver)
        {
            return;
        }
        CurHitObj = hit.collider.gameObject;
        if(CurHitObj == mLeftClose)
        {
            OpenLeftWindow(mIsLeftOpening);
        }
        //else if(CurHitObj == mLeftOpen)
        //{
        //    OpenLeftWindow(false);
        //}
        else if (CurHitObj == mRightClose)
        {
            OpenRightghtWindow(mIsRightOpening);
        }
        //else if (CurHitObj == mRightOpen)
        //{
        //    OpenRightghtWindow(false);
        //}
        else if(CurHitObj == mNoodleBox.gameObject)
        {
            ExcuteSayDialog("NoodleBox");
            mIsDia = true;
        }
        if(IsStart() && CurHitObj == gameObject)
        {
            mBoxColl.enabled = false;
            ExcuteView("ViewWindow");
        }

    }
    private bool IsStart()
    {
        return true;// GameLogicManager.Instance.IsCanOpenWindow;
    }
    private void OpenLeftWindow(bool isOpen)
    {
        mIsLeftOpening = !mIsLeftOpening;
        if(!mIsLeftOpening)
        {
            mNoodleBox.enabled = false;
        }
        mIsTweening = true;
        if (mIsLeftOpening)
        {
            mLeftClose.transform.DOScaleX(-0.5f, 0.8f).OnComplete(() => {
                //mLeftClose.SetActive(false);
                mIsTweening = false;
                //mLeftOpen.transform.DOScaleX(1, 0.5f).OnComplete(() => {
                //    mIsTweening = false;
                //});
            });
        }
        else
        {
            mLeftClose.transform.DOScaleX(1f, 0.8f).OnComplete(() => {
                //mLeftClose.SetActive(false);
                mIsTweening = false;
                //mLeftOpen.transform.DOScaleX(1, 0.5f).OnComplete(() => {
                //    mIsTweening = false;
                //});
            });
        }
        
        //mLeftClose.SetActive(!isOpen);
        //mLeftOpen.SetActive(isOpen);
        //mIsLeftOpening = isOpen;
    }
    private void OpenRightghtWindow(bool isOpen)
    {
        mIsRightOpening = !mIsRightOpening;
        if (!mIsRightOpening)
        {
            mNoodleBox.enabled = false;
        }
        mIsTweening = true;
        if (mIsRightOpening)
        {
            mRightClose.transform.DOScaleX(-0.5f, 0.8f).OnComplete(() => {
                mIsTweening = false;
            });
        }
        else
        {
            mRightClose.transform.DOScaleX(1f, 0.8f).OnComplete(() => {
                mIsTweening = false;
            });
        }
        //mIsRightOpening = isOpen;
    }
}
