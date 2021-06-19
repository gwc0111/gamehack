using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowObj : ObjBase
{
    private GameObject mLeftOpen;
    private GameObject mLeftClose;
    private GameObject mRightOpen;
    private GameObject mRightClose;
    public GameObject CurHitObj;
    private BoxCollider mBoxColl;
    public override void Init()
    {
        mLeftOpen = transform.Find("LeftOpen").gameObject;
        mLeftClose = transform.Find("LeftClose").gameObject;
        mRightClose = transform.Find("RightClose").gameObject;
        mRightOpen = transform.Find("RightOpen").gameObject;
        mBoxColl = GetComponent<BoxCollider>();
    }
    public override void OnObjMouseEnter()
    {

    }
    public override void OnObjMouseDown()
    {
        Debug.LogError("down");
    }
    public override void OnUpdateWithHit(RaycastHit hit, bool isMouseLeftDown)
    {
        
        if(isMouseLeftDown == false)
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
        if(IsStart() && CurHitObj == gameObject)
        {
            mBoxColl.enabled = false;
            Flowchart.ExecuteBlock("ViewWindow");
        }
    }
    private bool IsStart()
    {
        return true;
    }
    private void OpenLeftWindow(bool isOpen)
    {
        mLeftClose.SetActive(!isOpen);
        mLeftOpen.SetActive(isOpen);
    }
    private void OpenRightghtWindow(bool isOpen)
    {
        mRightClose.SetActive(!isOpen);
        mRightOpen.SetActive(isOpen);
    }
}
