using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class BACKDO_CLONE : MonoBehaviourPunCallbacks
{
    bool run;
    public float speed = 5f;
    public float runSpeed = 8f;

    public float DestroyTime = 5.0f;
    public Animator AN;

    private Vector3 moveDirection;
    private Vector3 destination;

    void Start()
    {
        destination = transform.position;
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * 5f;

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        AN.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
        //Vector3 spd = Vector3.zero;
        //transform.position = Vector3.SmoothDamp(transform.position, destination, ref spd, 0.05f);
    }

    void DestroyClone()
    {
        Destroy(gameObject);
    }
    
    [PunRPC]
    void CloneMove(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void HitBySlime(Vector3 origin)
    {
        Vector3 offset = new Vector3(0, -1, 0);
        this.destination = origin + offset;
    }
}