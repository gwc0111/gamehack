using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(mIsOver)
        {
            return;
        }
        CurHitObj = hit.collider.gameObject;
        if(CurHitObj == mLeftClose)
        {
            OpenLeftWindow(true);
        }
        else if(CurHitObj == mLeftOpen)
        {
            OpenLeftWindow(false);
        }
        else if (CurHitObj == mRightClose)
        {
            OpenRightghtWindow(true);
        }
        else if (CurHitObj == mRightOpen)
        {
            OpenRightghtWindow(false);
        }
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
        mLeftClose.SetActive(!isOpen);
        mLeftOpen.SetActive(isOpen);
        mIsLeftOpening = isOpen;
    }
    private void OpenRightghtWindow(bool isOpen)
    {
        mRightClose.SetActive(!isOpen);
        mRightOpen.SetActive(isOpen);
        mIsRightOpening = isOpen;
    }
}
