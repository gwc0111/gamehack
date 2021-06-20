using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Events;

public class CleanGameManager : MonoBehaviour
{
    [SerializeField] GameObject faceMask;
    [SerializeField] GameObject[] dirtyList;
    [SerializeField] string endBlock;
    [SerializeField] UnityEvent OnEndGame;
    [SerializeField] GameObject entrance;
    int lastDirtyCount;

    bool isPressing;
    // Start is called before the first frame update
    void Start()
    {
        lastDirtyCount = dirtyList.Length;
        faceMask.SetActive(false);

        StartCoroutine(setup());
    }

    IEnumerator setup()
    {
        yield return new WaitForSeconds(0.2f);

        faceMask.GetComponent<FaceMaskController>().KeyPressed.AddListener(() => isPressing = true);
        faceMask.GetComponent<FaceMaskController>().KeyReleased.AddListener(() => isPressing = false);

        foreach (var dirty in dirtyList)
        {
            dirty.GetComponent<DirtyThing>().DirtyDestroy.AddListener(() =>
            {
                if (--lastDirtyCount == 0)
                    EndGame();
            });
        }

    }

    void EndGame()
    {
        //var flowchart = FindObjectOfType<Flowchart>();
        //if(endBlock!="")
        //    flowchart.ExecuteBlock(endBlock);
        SceneController.instance.EndFocus();

        faceMask.SetActive(false);
        entrance.GetComponent<RoomSwitcher>().isOpen = true;

        OnEndGame.Invoke();
    }
}
