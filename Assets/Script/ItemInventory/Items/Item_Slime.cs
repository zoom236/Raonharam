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
         * VectorParams ���� 2���� ������ �ִ� Ŭ�����Դϴ�.
         * Vector3 characterPosition -> Current character's position Vector
         * Vector3 forwardVector -> Current chrarcter's forward Vector
         * 
         * ������ ��ȯ�� �ʿ��� ���� �ΰ� �޾ƾ�����
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
