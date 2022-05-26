using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Slime : MonoBehaviourPunCallbacks
{
    private Vector3 forwardVector;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;
        Debug.LogWarning("Go go Slime");
        
        RaycastHit hit;
        Ray ray = new Ray(startPosition, forwardVector);
        if (Physics.SphereCast(startPosition, 1, forwardVector, out hit, 10))
        {
            targetPosition = hit.point - startPosition;
            Debug.DrawRay(startPosition, targetPosition, Color.green, 5f);
        }
        else
        {
            targetPosition = forwardVector * 10f;
            Debug.DrawRay(startPosition, forwardVector * 10f, Color.red, 5f);
        }

        GetComponent<Rigidbody>().AddForce(forwardVector * 1000);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition - startPosition, 1f);
        
    }

    [PunRPC]
    void ActivateSlime(Vector3 forwardVector)
    {
        this.forwardVector = forwardVector;

        Destroy(gameObject, 3f);
    } 

}
