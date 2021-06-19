using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] string block;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var flowchart = FindObjectOfType<Flowchart>();
            if(flowchart != null)
            {
                flowchart.ExecuteBlock(block);
            }
        }

    }
}
