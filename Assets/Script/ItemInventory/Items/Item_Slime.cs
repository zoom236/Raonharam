using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item_Slime : MonoBehaviourPunCallbacks
{     
    void Fire(VectorParams vectorParams)
    {
        Debug.LogWarning("Use Slime");
        /*
         * VectorParams 벡터 2개를 가지고 있는 클래스입니다.
         * Vector3 characterPosition -> Current character's position Vector
         * Vector3 forwardVector -> Current chrarcter's forward Vector
         * 
         * 아이템 소환에 필요한 인자 두개 받아쓰세요
         * 
         * Vector3 spawnPosition = vectorParams.characterPosition + vectorParams.forwardVector;
         * PhotonNetwork.Instantiate("Slime", spawnPosition , Quaternion.identity);
         * 
         *
         */
        Vector3 spawnPosition = vectorParams.characterPosition + vectorParams.forwardVector;
        PhotonNetwork.Instantiate("Slime", spawnPosition , Quaternion.identity);

        Destroy(this.gameObject);
    }
}
