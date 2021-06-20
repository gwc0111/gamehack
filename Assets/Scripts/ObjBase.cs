using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ObjBase : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurObj;
    private Camera m_Camera;
    public GameObject mCMvcam1;
    public bool IsSelectObj = false;
    public Flowchart Flowchart;
    public CameraData mCamData = new CameraData();
    private bool mIsRayOnce = true;
    private GameObject mSayDiolog = null;
    private PlayerController mPlayer;
    public GameObject HoverPre;

    public bool mIsViewing = false;
    public bool mIsDialoging = false;
    public bool mIsTweening = false;
    private void Awake()
    {
        mPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        m_Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        CurObj = gameObject;
        Flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        mCMvcam1 = GameObject.Find("CM vcam1");
        mSayDiolog = GameObject.Find("SayDialog");
        HoverPre = Instantiate<GameObject>(HoverPre, transform);
        HoverPre.SetActive(false);
        Init();
    }
    public virtual void Init()
    { }
    public virtual void Play()
    { }
    private void Start()
    {

    }
    public void ExcuteSayDialog(string name)
    {
        Flowchart.ExecuteBlock(name);
        mIsDialoging = true;
        StartCoroutine(WaitDialogOver());
    }
    private IEnumerator WaitDialogOver()
    {
        if(mSayDiolog == null)
        {
            mSayDiolog = GameObject.Find("SayDialog");
        }
        yield return new WaitUntil(() => {
            return mSayDiolog.activeSelf == false;
        });
        mIsDialoging = false;

    }

    public void ExitView()
    {
        SceneController.instance.EndFocus();
        //OnResetCamera();
        //mCMvcam1.SetActive(true);
        //mPlayer.gameObject.SetActive(true);
    }
    private void OnResetCamera()
    {
        m_Camera.transform.position = mCamData.Pos;
        m_Camera.orthographicSize = mCamData.Size;
    }
    private void RecordCameraData()
    {
        mCamData.Pos = m_Camera.transform.position;
        mCamData.Size = m_Camera.orthographicSize;
    }
    public void ExcuteView(string viewName)
    {
        mPlayer.gameObject.SetActive(false);
        Flowchart.ExecuteBlock(viewName);
        RecordCameraData();
        mIsViewing = true;
        StartCoroutine(OnViewing());

    }
    private IEnumerator OnViewing()
    {
        yield return new WaitForSeconds(1);
        mIsViewing = false;
    }
    private void Update()
    {
        OnUpdate();
        bool isLeftDown = Input.GetMouseButtonDown(0);
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            GameObject gameobj = hit.collider.gameObject;
            //Debug.Log("hit Obj : " + gameobj + "  leftDown :" + isLeftDown);
            if(isLeftDown)
            {
                OnUpdateWithHit(hit, isLeftDown);
            }
        }
    }
    public virtual void OnUpdate() { }
    public virtual void OnUpdateWithHit(RaycastHit hit, bool mouseLeftDown)
    {

    }
    private void OnMouseOver()
    {
        OnObjMouseOver();
    }
    public virtual void OnObjMouseOver() { }
    private void OnMouseExit()
    {
        IsSelectObj = false;
        OnObjMouseExit();
    }
    public virtual void OnObjMouseExit() { }
    private void OnMouseDown()
    {

        OnObjMouseDown();
    }
    public virtual void OnObjMouseDown() { }
    private void OnMouseUp()
    {
        OnObjMouseUp();
    }
    private void OnMouseEnter()
    {
        OnObjMouseEnter();
    }
    public virtual void OnObjMouseEnter() { }
    public virtual void OnObjMouseUp() { }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.LogError("onpointclick");
    }
    public void OnObjMouseUp(PointerEventData eventData)
    {
        //Debug.LogError("onpointclick");
    }
}
