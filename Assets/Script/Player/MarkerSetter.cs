using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MarkerSetter : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject Marker;
    [SerializeField]
    Material Others;
    void Start() {
        if(!photonView.IsMine){
            Marker.GetComponent<MeshRenderer>().material = Others;
        }
        else{
            GameObject obj = GameObject.Find("PrivateMiniCam");
            if(obj != null){
                Debug.LogWarning($"TackPlayer.cs : {obj.GetComponent<TrackPlayer>()!=null}");
                obj.GetComponent<TrackPlayer>()?.SetTargetPlayer(transform);
            }
            else
                Debug.LogWarning("Cant Find");
        }
    }
}
