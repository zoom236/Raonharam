using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Grenade2 : MonoBehaviourPunCallbacks
{

    public PhotonView PV;

    Vector3 nextVec;

    private void Start()
    {
        Destroy(gameObject, 17f);

    }
    // Start is called before the first frame update
    void Go()
    {
        GameObject instantGrenade = PhotonNetwork.Instantiate("ThrowGrenade", transform.position, transform.rotation);
        Rigidbody rigidgrenade = instantGrenade.GetComponent<Rigidbody>();
        rigidgrenade.AddForce(nextVec, ForceMode.Impulse);
    }

    // Update is called once per frame
    [PunRPC]
    
    void DirRPC(Vector3 nextVec)
    {
        this.nextVec = nextVec;
        Go();

    }
}
