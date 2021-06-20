using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    public static GameLogicManager Instance;
    public bool IsFirstLevelOver = false;
    public bool IsCanOpenWindow = true;
    public bool IsCanOpenPhoto = true;
    private void Awake()
    {
        Instance = this;
    }

    public void SetIsCanOpenWindow(bool b)
    {
        IsCanOpenWindow = b;
    }

    public void SetIsCanOpenPhoto(bool b)
    {
        IsCanOpenPhoto = b;
    }
}
