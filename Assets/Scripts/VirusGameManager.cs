using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Fungus;
using UnityEngine.Events;

public class VirusGameManager : MonoBehaviour
{
    [SerializeField] GameObject virusPrefab;
    [SerializeField] Transform[] srcPosList;
    [SerializeField] Transform[] targetList;

    [SerializeField] ShaderController leftBuilding;
    [SerializeField] string endBlock;
    [SerializeField] UnityEvent OnGameFinish;
    //[SerializeField] string endBlock;
    bool isStart = false;

    private void Start()
    {
        OnGameFinish = new UnityEvent();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(.8f);

        leftBuilding.OnBuildingFinish.AddListener(GameFinish);
    }

    public void StartGame()
    {
        isStart = true;
    }


    // Update is called once per frame
    void Update()
    { 
        if(Input.GetMouseButtonDown(0) && isStart)
        {
            var virus = Instantiate(virusPrefab, transform);
            int randSrc = Random.Range(0f, 1f) > 0.8f ? 0 : 1;
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

        SceneController.instance.EndFocus();

        var flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(endBlock);
        }

        OnGameFinish.Invoke();
        //FindObjectOfType<Flowchart>().ExecuteBlock(endBlock);
    }
}
