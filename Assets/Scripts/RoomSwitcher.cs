using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] Transform target;
    public bool isOpen;

    bool inDoorArea;

    private void Start()
    {
        inDoorArea = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
            inDoorArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inDoorArea = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //切换房间
            GameObject player = GameObject.Find("Player");
            player.transform.position = target.position;
        }
    }
}
