using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BACKDO_KID : SkillBase
{
    private bool aimOnOff = false;

    public void Update()
    {
        CheckCoolTimeForUpdate();

        if (photonView.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                aimOnOff = !aimOnOff;

                if(aimOnOff)
                {
                    Debug.LogWarning("Targetting...");
                    ShowIndicator();
                }
                else
                {
                    Debug.LogWarning("Off");
                    HideIndicator();
                }
            }

            if(aimOnOff)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    SpawnObstacle();
                    //Debug.LogWarning("Spawning...");
                    aimOnOff = false;
                }

                if(Input.GetMouseButtonDown(1))
                {
                    //Debug.LogWarning("Cancel...");
                    aimOnOff = false;
                }
            }
        }
    }

    [PunRPC]
    public override void SkillFire()
    { 
        base.SkillFire();

    }

    // 장애물 소환 될 위치 표시
    public void ShowIndicator()
    {

    }

    public void HideIndicator()
    {

    }

    // 장애물 소환
    public void SpawnObstacle()
    {
        RaycastHit rayhit;
        Vector3 obstaclePos;
        Vector3 offset = new Vector3(0, 3, 0);
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out rayhit, 10))
        {
            Debug.LogWarning("OK");
            obstaclePos = rayhit.point;
        }
        else
        {
            Debug.LogWarning("NO!!!");
            obstaclePos = transform.position + transform.forward * 10f;
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red, 5f);
        }
        PhotonNetwork.Instantiate("RedBean", obstaclePos + offset, Quaternion.identity);
    }   
}
