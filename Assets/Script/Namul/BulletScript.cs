using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BulletScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    Vector3 nextVec;
    private void Start()
    {
        Destroy(gameObject, 3.5f);
    }
    //void Update() => transform.Translate(Vector3.forward * 7 * Time.deltaTime * dir);

    void Go()
    {
        Rigidbody rigidBean = this.GetComponent<Rigidbody>();
        rigidBean.AddForce(nextVec, ForceMode.Impulse);
    }

    [PunRPC]
    void DirRPC(Vector3 nextVec)
    {
        this.nextVec = nextVec;
        Go();
    }
}
