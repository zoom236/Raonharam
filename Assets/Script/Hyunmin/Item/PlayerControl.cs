using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Itemdetail[] items;
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


    void Start()
    {
       if(PV.IsMine)
        {
            EquipItem(0);

        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);

        }
    }

    void Update()
    {
        if (!PV.IsMine)
            return;//내꺼아니면 작동안함
        Look();
        Move();
        Jump();

        for (int i = 0; i < items.Length; i++)
        {
            if(Input.GetKeyDown((i+1).ToString())) //ToString으로 하면 입력받는 String을 숫자로 표현
            {
                EquipItem(i);
                //숫자키 1 2번으로 아이템 장착 가능

                break;

            }

        }

        if(Input.GetMouseButtonDown(0)) //0클릭 시
        {
            items[itemIndex].Use();   //들고 있는 아이템 사용

        }



    }
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
        //마우스 움직이는 정도*민감도만큼 각도 움직이기
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        //마우스 움직이는 정도*민감도만큼 각도 값 받기
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //y축 -90도에서 90도만 값으로 받음
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        //받은 각도로 카메라도 돌려줌

    }
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //벡더방향을 가지지만 크기는 1로 노말라이즈
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
        //왼쪽 쉬프트가 누르면 뛰는속도, 나머지는 걷는속도로하기
        //smoothTime만큼에 걸쳐서 이동해주기. 
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)//땅위에서 스페이스바 누르면
        {
            rb.AddForce(transform.up * jumpForce);//점프력만큼위로 힘받음
        }
    }

    void EquipItem(int _index)
    {
        if (_index == previousItemIndex)
            return;      //입력 받은 숫자 중복시 작동x
        itemIndex = _index;
        items[itemIndex].itemGameObject.SetActive(true); //itemIndex번쨰 아이템 on
        if (previousItemIndex != -1) //만약 초기 상태가 아니라면
        {
            items[previousItemIndex].itemGameObject.SetActive(false);
            //내가 아까 꼈던 아이템은 off
        }
        previousItemIndex = itemIndex;//무한 사이클
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;//내꺼아니면 작동안함
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        //이동하는거는 계산 끝난 moveAmount만큼만 고정된시간(0.2초)마다에 맞춰서
    }
}

