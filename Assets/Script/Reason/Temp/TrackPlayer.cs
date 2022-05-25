using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    Transform targetPlayer;
    bool isActive = false;
    public void SetTargetPlayer(Transform Obj){
        targetPlayer = Obj;
        isActive = true;
    }
    private void Update() {
        if(isActive){
            if(!Mathf.Approximately(transform.position.x,targetPlayer.position.x))
                transform.position = new Vector3(targetPlayer.position.x,transform.position.y,transform.position.z);
            if(!Mathf.Approximately(transform.position.z,targetPlayer.position.z))
                transform.position = new Vector3(transform.position.x,transform.position.y, targetPlayer.position.z);
        }
    }
}
