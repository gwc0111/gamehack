using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneFadeLoader : MonoBehaviour
{
    [SerializeField] Image blackImage;

    private void Awake()
    {
        blackImage.gameObject.SetActive(true);
        blackImage.DOFade(1, 0);

        StartCoroutine(setup());
    }

    IEnumerator setup()
    {
        yield return new WaitForSeconds(0.2f);
        ShowScene(true, 2);
    }

    public void ShowScene(bool isShow, float time = 1f)
    {
        blackImage.color = new Color(0,0,0, blackImage.color.a);
        SetMask(isShow, time);
    }

    public void ShowSceneWhite(bool isShow, float time = 1f)
    {
        blackImage.color = new Color(255, 255, 255, blackImage.color.a);
        SetMask(isShow, time);
    }

    void SetMask(bool isShow, float time = 1f)
    {
        blackImage.gameObject.SetActive(true);
        if (isShow)
        {
            blackImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
            blackImage.DOFade(0, time);
        }
        else
        {
            blackImage.GetComponent<CanvasGroup>().blocksRaycasts = true;
            blackImage.DOFade(1, time);
        }
    }

    IEnumerator GameObjectDisable(float time)
    {
        yield return new WaitForSeconds(time);
        blackImage.gameObject.SetActive(false);
        blackImage.DOFade(1, 0);
    }

    ////地图场景切换
    //public void FadeTo(string _sceneName, int _entranceIndex = 0)
    //{
    //    type = FadeType.Crossfade;
    //    StartCoroutine(LoadScene(_sceneName, _entranceIndex));
    //}

    //IEnumerator LoadScene(string sceneName, int entranceIndex)
    //{
    //    transitionDic[type].gameObject.SetActive(true);
    //    transitionDic[type].SetTrigger("Hide");
    //    yield return new WaitForSeconds(transitionTime);

    //    SceneManager.LoadScene(sceneName);
    //}
}
