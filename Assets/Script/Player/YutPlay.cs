using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class YutPlay: MonoBehaviourPunCallbacks
{
    [SerializeField]
    bool Dokkebi;
    delegate int Calculator<T>(T start, T end);
    Calculator<int> PICK;
    private void Start(){
        SetDel();       
    }
    void SetDel(){
        PICK += (start, end) => { return Random.Range(start, end); };
    }
    void Update(){
        if(photonView.IsMine){
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Ran();
            }
        }
    }
    void Ran(){
        List<string> Yut = new List<string>();

        Yut.Add("도");
        Yut.Add("개");
        Yut.Add("걸");
        Yut.Add("윷");
        Yut.Add("모");
        Yut.Add("빽도");

        int  Yute = 0;

        Yute = PICK(0, 15);

        if(Yute < 3)
        {
            Debug.Log(Yut[0]);
            photonView.RPC("Do_Comp",RpcTarget.All);
        }
        else if(Yute < 9)
        {
            Debug.Log(Yut[1]);
            photonView.RPC("Gae_Comp", RpcTarget.All);
        }
        else if (Yute < 13 )
        {
            Debug.Log(Yut[2]);
            photonView.RPC("Girl_Comp", RpcTarget.All);
        }
        else if (Yute < 14)
        {
            Debug.Log(Yut[3]);
            photonView.RPC("Yut_Comp", RpcTarget.All);
        }
        else if (Yute < 15)
        {
            Debug.Log(Yut[4]);
            photonView.RPC("Mo_Comp", RpcTarget.All);
        }
        else if (Yute < 16)
        {
            Debug.Log(Yut[5]);
            photonView.RPC("Backdo_Comp", RpcTarget.All);
        }        
    }
    [PunRPC]
    void Do_Comp() {
        gameObject.AddComponent<PlayerMovement>();
        if(Dokkebi)
            gameObject.AddComponent<DO_DOKI>();
        else
            gameObject.AddComponent<DO_KID>();
        Destroy(this);
    }
    [PunRPC]
    void Gae_Comp(){
        gameObject.AddComponent<PlayerMovement>();
        //if(Dokkebi)
        //    gameObject.AddComponent<GAE_DOKI>();
        //else
            //gameObject.AddComponent<GAE_KID>();
        Destroy(this);
    }
    [PunRPC]
    void Girl_Comp(){
        gameObject.AddComponent<PlayerMovement>();
        if(Dokkebi)
            gameObject.AddComponent<GIRL_DOKI>();
        else
            gameObject.AddComponent<GIRL_KID>();
        Destroy(this);
    }
    [PunRPC]
    void Yut_Comp(){
        gameObject.AddComponent<PlayerMovement>();
        if(Dokkebi)
            gameObject.AddComponent<YUT_DOKI>();
        else
            gameObject.AddComponent<YUT_KID>();
        Destroy(this);
    }
    [PunRPC]
    void Mo_Comp(){
        gameObject.AddComponent<PlayerMovement>();
        if(Dokkebi)
            gameObject.AddComponent<MO_DOKI>();
        else
            gameObject.AddComponent<MO_KID>();
        Destroy(this);
    }
    
    void Backdo_Comp(){
        gameObject.AddComponent<PlayerMovement>();
        if(Dokkebi)
            gameObject.AddComponent<BACKDO_DOKI>();
        else
            gameObject.AddComponent<BACKDO_KID>();
        Destroy(this);
    }
}
