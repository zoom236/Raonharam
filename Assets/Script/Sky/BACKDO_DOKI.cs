using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BACKDO_DOKI : SkillBase
{
    private Vector3 forward;
    private Vector3 right;
    private Vector3 moveDirection;
    
    void Update()
    {
        if(photonView.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            bool isMove = moveInput.magnitude != 0;

            forward = transform.TransformDirection(Vector3.forward);
            right = transform.TransformDirection(Vector3.right);
            moveDirection = forward * moveInput.y + right * moveInput.x;        

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GetComponent<PhotonView>().RPC("SpawnClone", RpcTarget.All);
                //SpawnClone();

                CheckCoolTimeForUpdate();
            }
        }
    }

    [PunRPC]
    public override void SkillFire()
    {
        base.SkillFire();
    }

    [PunRPC]
    public void SpawnClone()
    {
        PhotonNetwork.Instantiate("BACKDO_CLONE", transform.position + 2 * transform.forward, Quaternion.identity)
                    .GetComponent<PhotonView>().RPC("CloneMove", RpcTarget.All, moveDirection);
    }
}
