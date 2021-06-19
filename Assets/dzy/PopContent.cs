using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopContent : MonoBehaviour
{
    //设置从哪个摄像机发射射线
    public Camera m_Camera;
    //控制UI
    public GameObject m_UiPanel;

    // Use this for initialization
    void Start()
    {
        if(m_UiPanel == null)
        {
            return;
        }
        m_UiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            GameObject gameobj = hit.collider.gameObject;
            if (gameobj.tag == "PopContent")
            {
                Debug.LogError(gameobj.tag);
                gameobj.transform.Rotate(new Vector3(1, 1, 0));
            }
        }
    }
}
