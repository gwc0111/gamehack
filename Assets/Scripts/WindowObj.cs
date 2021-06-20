using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindowObj : ObjBase
{
    enum StepWindow
    {
        None,
        firOpenWindow,
        SecOpenWindow,
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

    private StepWindow mStep = StepWindow.None;
    public override void Init()
    {
        mLeftOpen = transform.Find("LeftOpen").gameObject;
        mLeftClose = transform.Find("LeftClose").gameObject;
        mRightClose = transform.Find("RightClose").gameObject;
        mRightOpen = transform.Find("RightOpen").gameObject;
        mBoxColl = GetComponent<BoxCollider>();
        mNoodleBox = GameObject.Find("NoodleBox").GetComponent<BoxCollider>();
        mNoodleBox.enabled = false;
        HoverPre.transform.position = new Vector3(3, 2, 0);
        HoverPre.SetActive(false);
    }
    public override void OnObjMouseOver()
    {
      if(GameLogicManager.Instance.IsCanOpenWindow && mBoxColl.enabled)
        {
            HoverPre.SetActive(true);
        }
      else
        {
            HoverPre.SetActive(false);
        }    
    }
    public override void OnObjMouseDown()
    {
        
    }
    public override void OnUpdate()
    {
        if(!mBoxColl.enabled)
        {
            HoverPre.SetActive(false);
        }
        if(mIsTweening)
        {
            return;
        }
        if(mIsOver)
        {
            return;
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
        if (CurHitObj == mLeftClose)
        {
            OpenLeftWindow(mIsLeftOpening);
        }
        ////else if(CurHitObj == mLeftOpen)
        ////{
        ////    OpenLeftWindow(false);
        ////}
        else if (CurHitObj == mRightClose)
        {
            OpenRightghtWindow(mIsRightOpening);
        }
        ////else if (CurHitObj == mRightOpen)
        ////{
        ////    OpenRightghtWindow(false);
        ////}
        //else if(CurHitObj == mNoodleBox.gameObject)
        //{
        //    ExcuteSayDialog("NoodleBox");
        //    mIsDia = true;
        //    mNoodleBox.enabled = false;
        //}
        if (IsStart() && CurHitObj == gameObject)
        {
            HoverPre.SetActive(false);
            mBoxColl.enabled = false;
            ExcuteView("ViewWindow");
            if(mStep == StepWindow.firOpenWindow || mStep == StepWindow.None)
            {
                StartCoroutine(OnOpenWindow());
            }
            else
            {
                StartCoroutine(SecOpenWindow());
            }
            
        }
        if (CurHitObj == mNoodleBox.gameObject)
        {
            ExcuteSayDialog("NoodleBox");
            mNoodleBox.enabled = false;
            StartCoroutine(OnNoodleDialog());
        }
    }
    private IEnumerator SecOpenWindow()
    {
        mLeftClose.GetComponent<BoxCollider>().enabled = true;
        mRightClose.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitUntil(() => { return mIsLeftOpening == false && mIsRightOpening == false; });
        ExitView();
        mLeftClose.GetComponent<BoxCollider>().enabled = false;
        mRightClose.GetComponent<BoxCollider>().enabled = false;
    }
    private IEnumerator OnNoodleDialog()
    {
        yield return new WaitUntil(()=> { return mIsDialoging == false; });
        mBoxColl.enabled = true;
        mStep = StepWindow.SecOpenWindow;
        yield return new WaitUntil(() => { return mIsLeftOpening == false && mIsRightOpening == false; });
        
    }

    public override void OnObjMouseExit()
    {
        HoverPre.SetActive(false);
    }
    private IEnumerator OnOpenWindow()
    {
        mNoodleBox.enabled = false;
        yield return new WaitUntil(()=> { return mIsLeftOpening && mIsRightOpening; });
        ExcuteSayDialog("AfterOpenWindow");
        yield return new WaitUntil(()=> { return mIsDialoging == false; });
        ExitView();
        mNoodleBox.enabled = true;
        mLeftClose.GetComponent<BoxCollider>().enabled = false;
        mRightClose.GetComponent<BoxCollider>().enabled = false;
    }
    private bool IsStart()
    {
        return  GameLogicManager.Instance.IsCanOpenWindow;
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
