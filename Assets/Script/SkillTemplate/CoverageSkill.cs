using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CoverageSkill : SkillBase{
	protected Collider Coverage;
	protected Player[] targets;
#region Virtual Methods
	protected virtual void getPlayers(){return;}
	protected virtual void giveEffect(Player[] targets){}
#endregion
#region Override Methods
	public override void SkillFire(){
		base.SkillFire();
		giveEffect(targets);
	}
#endregion
};