using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region --- helpers --     
    public enum enumFoot
    {
        Left,
        Right,
    }
    #endregion
    //블록화

    public float MoveSpeed = 3.0f;
    public float TurnSpeed = 90.0f;
    public float JumpStrength = 0.5f;
    public GameObject LeftPrefab = null;
    public GameObject RightPrefab = null;
    public float FootprintSpacer = 1.0f;
    private Vector3 LastFootprint;   //마지막 발자국 위치 추적
    private enumFoot WhichFoot;   //왼발인지 오른발인지
    private Rigidbody rb = null;
    private bool TouchingGround;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        SpawnDecal(LeftPrefab);
        LastFootprint = this.transform.position;
    }
    private void Update()
    {
        //Rotate and Move: (WASD, Arrow keys, Left Analog Joystick)        
        float rotationY = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, rotationY * TurnSpeed * Time.deltaTime);
        float moveZ = Input.GetAxis("Vertical");
        this.transform.Translate(0.0f, 0.0f, moveZ * MoveSpeed * Time.deltaTime);

        //Jump: (Left ctrl, Left mouse button, Joystick button X)
        if (Input.GetButton("Fire1") == true && TouchingGround == true)
        {
            rb.AddForce(Vector3.up * JumpStrength, ForceMode.VelocityChange);
        }      

        if (moveZ != 0 && TouchingGround == true)      //내가 발자국을 남길지 여부 결정
        {
            //distanct since last footprint, determines 
            float DistanceSinceLastFootprint = Vector3.Distance(LastFootprint, this.transform.position);
            if (DistanceSinceLastFootprint >= FootprintSpacer)
            {
                if (WhichFoot == enumFoot.Left)    //발이 왼쪽과 같으면 
                {
                    SpawnDecal(LeftPrefab);
                    WhichFoot = enumFoot.Right;
                }
                else if (WhichFoot == enumFoot.Right)
                {
                    SpawnDecal(RightPrefab);
                    WhichFoot = enumFoot.Left;
                }
                LastFootprint = this.transform.position;  //새 발자국과 다음 발자국 사이의 거리 측정
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            TouchingGround = true;
            SpawnDecal(LeftPrefab);
            SpawnDecal(RightPrefab);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            TouchingGround = false;
        }
    }
    private void SpawnDecal(GameObject prefab)
    {
        //we want to cast a ray(line) from the player to the ground
        Vector3 from = this.transform.position;
        Vector3 to = new Vector3(this.transform.position.x, this.transform.position.y - (this.transform.localScale.y / 2.0f) + 0.1f, this.transform.position.z);
        Vector3 direction = to - from;

        RaycastHit hit;
        if (Physics.Raycast(from, direction, out hit) == true)
        {
            //where the ray hits the ground we will place a footprint
            GameObject decal = Instantiate(prefab);
            decal.transform.position = hit.point;
            //turn the footprint to match the direction the player is facing
            decal.transform.Rotate(Vector3.up, this.transform.eulerAngles.y);
        }
    }
}