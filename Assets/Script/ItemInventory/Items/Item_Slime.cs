using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_Slime : MonoBehaviourPunCallbacks
{     
    void Fire(GameObject myPlayer)
    {
        Debug.LogWarning("Use Slime");
        /*
         * 
         * 
         * 
         */
        Vector3 offset = new Vector3(0, 1, 0);
        Vector3 spawnPosition = myPlayer.transform.position + myPlayer.transform.forward + offset;
        PhotonNetwork.Instantiate("Slime", spawnPosition, Quaternion.Euler(-90, 0, 90))
            .GetComponent<Slime>().ActivateSlime(myPlayer.transform.forward);

        Destroy(this.gameObject);
    }
}
