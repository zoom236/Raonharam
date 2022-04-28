using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerScript_old : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    private Transform characterBody;    // ĳ����
    [SerializeField]
    private Transform cameraArm;        // ī�޶� ȸ��

    Animator anim;
    Rigidbody rigid;

    bool jDown;  // ����
    bool isJump;

    bool sDown;  // �ɱ�
    bool isSit;

    bool tDown;  // �Ͼ��
    bool isStand;

    public Rigidbody RB;
    public Animator AN;
    //public SpriteRenderer SR;
    public PhotonView PV;
    public Text NickNameText;
    //public Image HealthImage;

    Vector3 curPos;

    //bool swDown;  // �������¿��� �ȱ�
    //bool isSitWalk;

    //RedBeanSpawn redbeanspawn;      // ������ ����Ȯ��

    //private int ToggleView = 3; // 1=1��Ī, 3=3��Ī

    void Awake()
    {
        anim = characterBody.GetComponent<Animator>();        // characterBody.GetComponent
        rigid = characterBody.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //redbeanspawn = GameObject.Find("Spawn").GetComponent<RedBeanSpawn>();

        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;
    }

    void Update()
    {
        GetInput();     // Ű �Է�
        Move();         // �÷��̾� �̵�
        LookAround();   // ī�޶� �ü� �̵�
        SitMove();      // �ɾƼ� �̵�
        Jump();         // ����
        Sit();          // �ɱ�
        Stand();        // �Ͼ��
        Throw();        // ������
    }

    void GetInput()
    {
        jDown = Input.GetButtonDown("Jump");
        sDown = Input.GetKeyDown(KeyCode.LeftControl);

        if (sDown && isSit)
        {
            tDown = Input.GetKeyDown(KeyCode.LeftControl);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Smoke();
        }
    }

    void Smoke()
    {
        PhotonNetwork.Instantiate("SmokeGrenade", transform.position, Quaternion.identity);
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;   // moveInput�� 0�̸� �̵��Է��� ���°�
        anim.SetBool("isRun", isMove);

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            //characterBody.forward = moveDir;
            characterBody.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * 5f;

            //if (Input.GetKeyDown(KeyCode.LeftAlt))
            //{
            //    characterBody.forward = lookForward;
            //}
            //else
            //{
            //    characterBody.forward = moveDir;
            //}
        }


        //Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);
    }
    void Sit()
    {
        if (sDown && !isSit)
        {
            anim.SetBool("isSit", true);
            isSit = true;
        }
        //isSit = false;
    }

    void SitMove()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;   // moveInput�� 0�̸� �̵��Է��� ���°�
        anim.SetBool("isSitWalk", isMove);

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;
            //characterBody.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * 0.5f;
        }
    }

    void Stand()
    {
        if (tDown && isSit && !isStand)
        {
            anim.SetBool("isStand", true);
            isStand = true;
        }
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            //anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Throw()
    {
        if (GameObject.Find("Spawn").GetComponent<RedBeanSpawn>().RedBeanUse == true)
        {
            Debug.Log("������");
            anim.SetTrigger("doThrow");
        }
        
    }

    private void LookAround()       // ī�޶� ȸ�� ���
    {
        //Debug.DrawRay(cameraArm.position, cameraArm.forward * 100f, Color.red);
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));       // mouse x = ���콺 �¿� ��ġ, mouse y = ���콺 ���� ��ġ 
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("����");
            //anim.SetBool("isJump", false);
            isJump = false;
            isSit = false;
            isStand = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
