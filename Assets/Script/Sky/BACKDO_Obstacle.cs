using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BACKDO_Obstacle : MonoBehaviourPunCallbacks
{
    public float DestroyTime = 2.0f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
