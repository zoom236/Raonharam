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

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * 5f;

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        AN.SetFloat("Blend", percent, 0.1f, Time.deltaTime);

        Ray[] rays = new Ray[4];
        rays[0] = new Ray(transform.position, transform.forward);
        rays[1] = new Ray(transform.position, -transform.forward);
        rays[2] = new Ray(transform.position, transform.right);
        rays[3] = new Ray(transform.position, -transform.right);
        RaycastHit rayhit;

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], out rayhit, 1))
            {
                DestroyClone();
                return;
            }
        }

    }

    void DestroyClone()
    {
        Destroy(gameObject);
    }
    
    [PunRPC]
    void CloneMove(Vector3 direction)
    {
        //Debug.LogWarning("CLONEMOVE");

        moveDirection = direction;
    }
}