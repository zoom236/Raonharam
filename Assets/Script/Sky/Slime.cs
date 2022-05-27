using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Slime : MonoBehaviourPunCallbacks
{
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition - startPosition, 1f);
        Vector3 spd = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref spd, 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            // юс╫ц            
            other.GetComponent<BACKDO_CLONE>().HitBySlime(startPosition);
            Destroy(this.gameObject);
        }
    }

    public void ActivateSlime(Vector3 forwardVector)
    {
        startPosition = transform.position;
        targetPosition = transform.position;
        Debug.LogWarning("Go go Slime");

        RaycastHit hit;
        Ray ray = new Ray(startPosition, forwardVector);
        if (Physics.SphereCast(startPosition, 1, forwardVector, out hit, 10))
        {
            targetPosition = hit.point;
            //Debug.DrawRay(startPosition, targetPosition, Color.green, 5f);
        }
        else
        {
            targetPosition = startPosition + forwardVector * 10f;
            //Debug.DrawRay(startPosition, targetPosition, Color.red, 5f);
        }

        Destroy(this.gameObject, 2f);
    } 

}
