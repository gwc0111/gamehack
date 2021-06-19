using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void StartFocus()
    {
        player.SetActive(false);
        cinemachine.SetActive(false);
    }


    public void EndFocus()
    {
        player.SetActive(true);
        cinemachine.SetActive(true);
    }
    
}
