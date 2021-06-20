using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class WindowManager : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] UnityEvent OnWindowOpen;

    bool leftOpen = false;
    bool rightOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        //OnWindowOpen = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject == left)
                {
                    left.transform.DOScaleX(-0.5f, 1);
                    leftOpen = true;
                    WindowOpen();
                }
                else if (hit.collider.gameObject == right)
                {
                    right.transform.DOScaleX(-0.5f, 1);
                    rightOpen = true;
                    WindowOpen();
                }

            }
        }
    }

    void WindowOpen()
    {
        if(leftOpen && rightOpen)
        {
            OnWindowOpen.Invoke();
        }
    }
}
