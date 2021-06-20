using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button StartBtn;
    public Button ExitBtn;
    public GameObject MenuPrs;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(OnStartBtn);
        ExitBtn.onClick.AddListener(OnExitBtnClick);
    }

    private void OnStartBtn()
    {
        Debug.LogError("OnStart");

    }
    private void OnExitBtnClick()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
