using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BACKDO_KID : SkillBase
{
    public GameObject Kid;
    private bool aimOnOff = false;
    private GameObject Indicator;

    public void Start()
    {
        Vector3 offset = new Vector3(0, -1, 10);
        Indicator = PhotonNetwork.Instantiate("Indicator", transform.position + offset, Quaternion.Euler(0,90,0));
        Indicator.transform.SetParent(Kid.transform, false);
        Indicator.SetActive(false);
    }

    public void Update()
    {
        CheckCoolTimeForUpdate();

        Indicator.transform.localPosition = GetIndicatorPosition();

        if (photonView.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                aimOnOff = !aimOnOff;

                if(aimOnOff)
                {
                    Debug.LogWarning("Targetting...");
                    Indicator.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Off");
                    Indicator.SetActive(false);
                }
            }

            if(aimOnOff)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    SpawnObstacle();
                    //Debug.LogWarning("Spawning...");
                    aimOnOff = false;
                    Indicator.SetActive(false);
                    //SkillFire();
                }

                if(Input.GetMouseButtonDown(1))
                {
                    //Debug.LogWarning("Cancel...");
                    aimOnOff = false;
                    Indicator.SetActive(false);
                }
            }
        }
    }

    [PunRPC]
    public override void SkillFire()
    { 
        base.SkillFire();
    }

    public Vector3 GetIndicatorPosition()
    {
        RaycastHit rayhit;
        Vector3 indicatorPos;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out rayhit, 10))
        {
            indicatorPos = rayhit.point - transform.position;
        }
        else
        {
            indicatorPos = transform.forward * 10f;
        }
        return indicatorPos;
    }

    // 장애물 소환
    public void SpawnObstacle()
    {
        RaycastHit rayhit;
        Vector3 obstaclePos;
        Vector3 offset = new Vector3(0, 5, 0);
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
        PhotonNetwork.Instantiate("Obstacle", obstaclePos + offset, Quaternion.Euler(0,90,0));
    }
}
