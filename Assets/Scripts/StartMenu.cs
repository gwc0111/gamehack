using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
        //BGMManager.instance.PlayAudioEffect("StartMenu");
        //MenuPrs.transform.DOScaleX(0, 0.5f).OnComplete(()=> { MenuPrs.SetActive(false); });
        SceneManager.LoadScene("Main");
    }
    private void OnExitBtnClick()
    {
        Application.Quit();
    }
}
