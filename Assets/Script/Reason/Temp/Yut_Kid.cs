using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Yut_Kid : CoverageSkill{
	PhotonView pv;
#region MonoBehaviour CallBacks
 private void Awake() {
		pv = GetComponent<PhotonView>();
		Coverage = gameObject.AddComponent<SphereCollider>();
		((SphereCollider)Coverage).radius = 3f;
	}
	private void Update() {
		if(pv.IsMine){
			if(Input.GetKey(KeyCode.Q)){
				pv.RPC("SkillFire",RpcTarget.All);
			}
		}
	}
	private void OnTriggerEnter(Collider other){
	}
#endregion
#region Override Methods
	protected override void getPlayers(){
		return;
	}
	public override void SkillFire(){
		base.SkillFire();
	}
#endregion
};