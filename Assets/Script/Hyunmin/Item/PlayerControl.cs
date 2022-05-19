using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Item[] items;
    public int itemIndex;
    public int previousItemIndex = -1; //기본 아이템 값 없도록
    //마우스감도 뛰는속도 걷는속도 점프힘 뛰기걷기바꿀때 가속시간
    float verticalLookRotation;
    bool grounded; //점프를 위한 바닥체크
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount; //실제 이동거리

    Rigidbody rb;
    PhotonView PV;

     void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }


}
