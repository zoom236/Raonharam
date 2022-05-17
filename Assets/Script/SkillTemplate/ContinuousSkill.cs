using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContinuousSkill: SkillBase{
	protected float EffctTime = 1f;
	private float effect_counter = 0f;

	private float SkillUseTime = 0f;   //사용지속시간
	private float SkillReuseTime = 0f;  //재사용시간
	private AudioSource SkillSound = null;   //소리

	//skillEndCondition variable
	private float SkillTimeOver;  //시간종료

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

	public void ChildAbility()   //아이능력
    {

    }

	public void DokiAbility() //도깨비 능력
    {

    }

	public void SkillEndCondition() //스킬해제조건
    {

    }

	//타플레이어 아이템 사용시
	void OnCollisionEnter(Collision ObjectColiisionSkillEnd)   //충돌시 스킬 해제
    {

    }

	void OnTriggerEnter(Collider ObjectColiisionSkillEnd)
    {

    }
};