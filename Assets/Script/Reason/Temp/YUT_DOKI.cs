using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class YUT_DOKI : CoverageSkill,IPunObservable
{
    Camera Minicam;
    void Start(){
        Minicam = GameObject.Find("PrivateMiniCam").GetComponent<Camera>();
        if(Minicam == null){
            Debug.Log("Can't Find Minicam");
        }
    }
    void Update() {
        if(photonView.IsMine){
            if(Input.GetKeyDown(KeyCode.Q)){
                SkillFire();
            }
            CheckCoolTimeForUpdate();
        }    
    }
	protected override void getPlayers(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players){
            if(player.name.StartsWith("Kid"))
                targetList.Add(player.GetComponent<PhotonView>());
        }
	}
	protected override void giveEffect()
	{
        if(targetList.Count<=0) return;
        foreach(PhotonView pv in targetList){
            pv.GetComponent<MarkerSetter>().MarkerVisible(true);
        }
	}
	public override void SkillFire()
	{
        if(isEffectiveness()){
            targetList.Clear();
            getPlayers();
            giveEffect();
		    base.SkillFire();
        }
	}
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo messageInfo){
        if(stream.IsWriting){
            SkillBaseUpstream(stream);
        }
        else{
            SkillBaseDownstream(stream);
        }
    }
}
