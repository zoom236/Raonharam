using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BACKDO_DOKI : SkillBase
{ 
    void Update()
    {
        if(photonView.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            bool isMove = moveInput.magnitude != 0;

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;        

            if (Input.GetKeyDown(KeyCode.Q))
            {                
                PhotonNetwork.Instantiate("BACKDO_CLONE", transform.position + 2 * transform.forward, Quaternion.identity)
                    .GetComponent<PhotonView>().RPC("CloneMove", RpcTarget.All, moveDirection);
            }
        }
    }

    [PunRPC]
    public override void SkillFire()
    {
        base.SkillFire();
    }
}
