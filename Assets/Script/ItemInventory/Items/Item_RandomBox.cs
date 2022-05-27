using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_RandomBox : MonoBehaviourPunCallbacks
{
    void Fire(GameObject myPlayer)
    {
        Debug.LogWarning("Use RandomBox");
        /*
         * 
         * 
         *
         */
        Destroy(this.gameObject);
    }
}
