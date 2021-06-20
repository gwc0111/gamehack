using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VaseBroken : MonoBehaviour
{
    [SerializeField] GameObject[] vaseList;
    [SerializeField] string endBlock;
    public bool enable = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enable)
            return;

        if (collision.gameObject.tag == "Player" && !GameLogicManager.Instance.IsFirstLevelOver)
        {
            StartCoroutine(VaseIsBroken());
        }
    }

    IEnumerator VaseIsBroken()
    {
        for(int i=1;i<vaseList.Length;++i)
        {
            vaseList[i-1].SetActive(false);
            vaseList[i].SetActive(true);

            if(i == vaseList.Length-1)
            {
                BGMManager.instance.PlayAudioEffect("VaseBroken");
                yield return new WaitForSeconds(1f);

                var flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
                flowchart.ExecuteBlock(endBlock);

                GetComponent<BoxCollider2D>().enabled = false;
            }

            yield return new WaitForSeconds(0.4f);
        }

    }

}
