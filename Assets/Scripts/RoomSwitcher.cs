﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] PolygonCollider2D targetCollider;
    public bool isOpen;

    bool inDoorArea;

    private void Start()
    {
        inDoorArea = false;
    }

    public void SetEnable(bool b)
    {
        enabled = b;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        inDoorArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inDoorArea = false;
    }

    
    private void Update()
    {
        if (!inDoorArea)
            return;

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isOpen)
            {
                BGMManager.instance.PlayAudioEffect("CantOpenDoor");
                return;
            }

            //切换房间
            GameObject player = GameObject.Find("Player");
            player.transform.position = target.position;

            FindObjectOfType<Cinemachine.CinemachineConfiner>().m_BoundingShape2D = targetCollider;

            inDoorArea = false;

            BGMManager.instance.PlayAudioEffect("OpenDoor");
        }
    }
}
