using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjBase : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurObj;
    private Camera m_Camera;
    public bool IsSelectObj = false;
    public Flowchart Flowchart;
    private void Awake()
    {
        m_Camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        CurObj = gameObject;
        Flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        Init();
    }
    public virtual void Init()
    { }
    public virtual void Play()
    { }
    private void Start()
    {

    }
    private void Update()
    {
        OnUpdate();
        bool isLeftDown = Input.GetMouseButtonUp(0);
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            GameObject gameobj = hit.collider.gameObject;
            Debug.Log("hit Obj : " + gameobj + "  leftDown :" + isLeftDown);
            OnUpdateWithHit(hit, isLeftDown);
        }
        
    }
    public virtual void OnUpdate() { }
    public virtual void OnUpdateWithHit(RaycastHit hit,bool mouseLeftDown)
    {

    }
    private void OnMouseExit()
    {
        IsSelectObj = false;
    }
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
        Debug.LogError("onpointclick");
    }
    public void OnObjMouseUp(PointerEventData eventData)
    {
        Debug.LogError("onpointclick");
    }
}
