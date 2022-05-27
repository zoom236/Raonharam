using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_SweetPotato : MonoBehaviourPunCallbacks
{
    void Fire(GameObject myPlayer)
    {
        Debug.LogWarning("Use SweetPotato");
        /*
         * 
         * 
         *
         */
        Destroy(this.gameObject);
    }
}
