using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_WhoopeeCushion : MonoBehaviourPunCallbacks
{
    void Fire(Vector3 position)
    {
        Debug.LogWarning("Use WhoopeeCushion");
        /*
         *  
         * 
         * 
         * PhotonNetwork.Instantiate("Indicator", position, Quaternion.Euler(0, 90, 0));
         *
         *
         *
         */
        Destroy(this.gameObject);
    }
}
