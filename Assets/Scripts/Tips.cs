using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] string block;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !GameLogicManager.Instance.IsFirstLevelOver)
        {
            var flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if(flowchart != null)
            {
                flowchart.ExecuteBlock(block);
            }
        }

    }
}
