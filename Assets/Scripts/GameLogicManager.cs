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
        IsCanOpenPhoto = true;
        IsCanOpenWindow = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
