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
    public int previousItemIndex = -1; //�⺻ ������ �� ������
    //���콺���� �ٴ¼ӵ� �ȴ¼ӵ� ������ �ٱ�ȱ�ٲܶ� ���ӽð�
    float verticalLookRotation;
    bool grounded; //������ ���� �ٴ�üũ
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount; //���� �̵��Ÿ�

    Rigidbody rb;
    PhotonView PV;

     void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }


}
