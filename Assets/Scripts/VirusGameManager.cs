﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VirusGameManager : MonoBehaviour
{
    [SerializeField] GameObject virusPrefab;
    [SerializeField] Transform[] srcPosList;
    [SerializeField] Transform[] targetList;

    [SerializeField] ShaderController leftBuilding;
    bool isStart = true;

    private void Start()
    {
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(.8f);

        leftBuilding.OnBuildingFinish.AddListener(GameFinish);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isStart)
        {
            var virus = Instantiate(virusPrefab, transform);
            int randSrc = Random.Range(0, srcPosList.Length);
            virus.transform.position = srcPosList[randSrc].transform.position;

            int randTarget = Random.Range(0, targetList.Length);
            virus.transform.DOMove(targetList[randTarget].position, 1f);
        }

    }

    void GameFinish()
    {
        isStart = false;
        leftBuilding.gameObject.SetActive(false);

        foreach(var src in srcPosList)
        {
            Destroy(src.gameObject);
        }
    }
}
