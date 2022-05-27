using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_WhoopeeCushion : MonoBehaviourPunCallbacks
{
    void Fire(GameObject myPlayer)
    {
        Debug.LogWarning("Use WhoopeeCushion");
        /*
         * 
         * 
         *
         */
        Destroy(this.gameObject);
    }
}
