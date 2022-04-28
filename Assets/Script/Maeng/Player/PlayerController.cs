using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    bool jDown;  // ����
    bool isJump;

    bool sDown;  // �ɱ�
    bool isSit;

    bool tDown;  // �Ͼ��
    bool isStand; 

    bool swDown;  // �������¿��� �ȱ�
    bool isSitWalk;
    
    Vector3 moveVec;
    Vector3 sitmoveVec;
    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        //Move();
        Trun();
        Jump();
        Sit();
        Stand();
        SitMove();
    }

    void GetInput()
    {
        //hAxis = Input.GetAxisRaw("Horizontal");
        //vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");
        sDown = Input.GetKeyDown(KeyCode.LeftControl);

        if (sDown && isSit)
        {
            tDown = Input.GetKeyDown(KeyCode.LeftControl);
        }
        
    }

    //void Move()
    //{
    //    moveVec = new Vector3(hAxis, 0, vAxis).normalized;
    //    transform.position += moveVec * speed * Time.deltaTime;

    //    anim.SetBool("isRun", moveVec != Vector3.zero);
    //}

    void SitMove()
    {
        if (isSit)
        {
            sitmoveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += moveVec * (speed * 0.5f) * Time.deltaTime;

            anim.SetBool("isSitWalk", sitmoveVec != Vector3.zero);
        }
    }

    void Trun()
    {
        transform.LookAt(transform.position + moveVec);
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

    void Sit()
    {
        if (sDown && !isSit)
        {
            anim.SetBool("isSit", true);
            isSit = true;
        }
        //isSit = false;
    }

    void Stand()
    {
        if (tDown && isSit && !isStand)
        {
            anim.SetBool("isStand", true);
            isStand = true;
        }
        //else
        //{
        //    anim.SetBool("isSit", false);
        //    anim.SetBool("isStand", false);
        //}
            
    }

    void SitWalk()
    {
        if (swDown && isSit)
        {
            anim.SetBool("isSitWalk", true);
            isSitWalk = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //anim.SetBool("isJump", false);
            isJump = false;
            isSit = false;
            isStand = false;
        }
    }
}
