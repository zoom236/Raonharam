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
    [SerializeField]
    Texture2D OtherTex;
    [SerializeField]
    float ShownTime = 10f;
    void Start() {
        if(!photonView.IsMine){
            Marker.GetComponent<MeshRenderer>().material.mainTexture = OtherTex;
            Marker.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            MarkerVisible(false);
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
    public void MarkerVisible(bool isVisible){
        Marker?.SetActive(isVisible);
        if(isVisible){
            StopCoroutine(MarkResetHide());
            StartCoroutine(MarkResetHide());
        }
    }
    IEnumerator MarkResetHide(){
        yield return new WaitForSeconds(ShownTime);
        MarkerVisible(false);
    }
}
