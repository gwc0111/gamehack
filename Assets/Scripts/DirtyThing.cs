using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirtyThing : MonoBehaviour
{
    public UnityEvent DirtyDestroy;

    private void Start()
    {
        DirtyDestroy = new UnityEvent();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("FaceMask"))
        {
            DirtyDestroy.Invoke();

            Destroy(gameObject);
        }
    }
}
