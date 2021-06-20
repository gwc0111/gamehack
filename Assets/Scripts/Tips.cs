using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Events;

public class Tips : MonoBehaviour
{
    [SerializeField] string block;
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] bool enable = true;

    private void Start()
    {
        OnEnter = new UnityEvent();
    }

    public void SetEnable(bool b)
    {
        enable = b;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enable)
            return;
        if(collision.gameObject.tag == "Player")
        {
            var flowchart = FindObjectOfType<Flowchart>();
            if(flowchart != null)
            {
                flowchart.ExecuteBlock(block);
            }
            OnEnter.Invoke();

            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
