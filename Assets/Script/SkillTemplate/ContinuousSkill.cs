using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContinuousSkill: SkillBase{
	protected float EffctTime = 1f;
	private float effect_counter = 0f;

	private float SkillUseTime = 0f;
	private float SkillReuseTime = 0f;
	private AudioSource SkillSound = null;

	//skillEndCondition variable
	private float SkillTimeOver;

#region Virtual Methods
	protected virtual bool canCancel(){return false;}
	protected virtual void giveEffect(){}
	protected virtual void removeEffect(){	//In Subclass, Must use base.removeEffect();
		effect_counter = 0f;
	}
#endregion
#region Override Methods
	[PunRPC]
	public override void SkillFire(){
		base.SkillFire();
		giveEffect();
	}

#endregion
	protected void CheckSkillEffectforUpdate(){
		if(true){ //Condition means a state that effect is on
			effect_counter += Time.deltaTime;
			if(canCancel()||(effect_counter<=EffctTime))
				removeEffect();
		}
	}

	public void ChildAbility()
    {

    }

	public void DokiAbility()
    {

    }

	public void SkillEndCondition()
    {

    }

	//타플레이어 아이템 사용시
	void OnCollisionEnter(Collision ObjectColiisionSkillEnd)
    {

    }

	void OnTriggerEnter(Collider ObjectColiisionSkillEnd)
    {

    }
};