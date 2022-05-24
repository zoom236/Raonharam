using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CoverageSkill : SkillBase{
	protected bool skillOnce = false;
	protected Collider Coverage;
	protected Player[] targets;
	public List<PhotonView> targetList;
#region Virtual Methods
	protected virtual void getPlayers(){return;}
	protected virtual void giveEffect(Player[] targets){}
	protected virtual void giveEffect(PhotonView[] targets){}
	protected virtual void giveEffect(){}
#endregion
#region Override Methods
	public override void SkillFire(){
		skillOnce = true;
		base.SkillFire();
	}
#endregion
};