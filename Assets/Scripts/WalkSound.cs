using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public void LeftSound()
    {
        BGMManager.instance.PlayAudioEffect("WalkLeft");
    }

    public void RightSound()
    {
        BGMManager.instance.PlayAudioEffect("WalkRight");
    }
}
