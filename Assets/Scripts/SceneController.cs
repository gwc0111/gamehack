using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    #region Singleton
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    // Start is called be

    [SerializeField] GameObject player;
    [SerializeField] GameObject cinemachine;
    [SerializeField] SpriteRenderer mask;

    public void StartFocus()
    {
        player.SetActive(false);
        cinemachine.SetActive(false);
    }


    public void EndFocus()
    {
        StartCoroutine(AsynEndFocus());
    }

    IEnumerator AsynEndFocus()
    {
        HideScene(0.5f);
        yield return new WaitForSeconds(0.5f);

        player.SetActive(true);
        cinemachine.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        ShowScene(0.5f);
    }

    public void ShowScene(float time = 0.5f)
    {
        mask.DOFade(0, time);
    }

    public void HideScene(float time = 0.5f)
    {
        mask.gameObject.SetActive(true);
        mask.DOFade(1, time);
    }
}
