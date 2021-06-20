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

        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.2f);
        BGMManager.instance.PlayBGM("Title");
    }

    private void OnStartBtn()
    {
        //BGMManager.instance.PlayAudioEffect("StartMenu");
        //MenuPrs.transform.DOScaleX(0, 0.5f).OnComplete(()=> { MenuPrs.SetActive(false); });

        BGMManager.instance.PlayAudioEffect("Button");
        FindObjectOfType<SceneFadeLoader>().ShowScene(false);

        StartCoroutine(LoadMain());
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Main");
    }

    private void OnExitBtnClick()
    {
        BGMManager.instance.PlayAudioEffect("Button");
        Application.Quit();
    }
}
