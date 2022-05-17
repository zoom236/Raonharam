using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    Rigidbody rb;
    bool isJump;
    bool toggleCameraRotation;
    bool run;
    public float speed = 5f;
    public float runSpeed = 8f;
    public float finalSpeed;
    public float smoothness = 10f;
    [SerializeField]
    Text NickNameText;
    public Animator AN;
    void Awake(){
        rb = GetComponent<Rigidbody>();
        NickNameText.text = photonView.IsMine ? PhotonNetwork.NickName : photonView.Owner.NickName;
        NickNameText.color = photonView.IsMine ? Color.green : Color.red;
        isJump = false;
        if(photonView.IsMine && PhotonNetwork.IsConnected){
            Camera.main.transform.GetComponentInParent<CameraMovement>().objectTofollow = transform.Find("FollowCam").transform;
        }
    }
    void Update(){
        if(photonView.IsMine == false && PhotonNetwork.IsConnected == true){
            return;
        }
        if(photonView.IsMine){
        #region Player Input
            if(Input.GetKeyDown(KeyCode.Space)&&!isJump){
                Jump();
                isJump = true;
            }
        #endregion
        }
        Move();
    }
#region Custom Rpc Methods
    [PunRPC]
    void Jump(){
        rb.AddForce(Vector3.up * 400f);
    }
#endregion
    void Move()
    {
        if (photonView.IsMine)
        {
            finalSpeed = (run) ? runSpeed : speed;

            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            bool isMove = moveInput.magnitude != 0;   // moveInput�� 0�̸� �̵��Է��� ���°�

            if (isMove)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

                transform.position += moveDirection * Time.deltaTime * 5f;

                rb.AddForce(moveDirection * 3);

                float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
                AN.SetFloat("Blend", percent, 0.1f, Time.deltaTime);

            }
        }
    //    else if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos;
    //    else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag =="Ground")
            isJump = false;
    }
}
