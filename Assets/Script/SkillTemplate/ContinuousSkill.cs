using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContinuousSkill: SkillBase{
	protected float EffctTime = 1f;             // 효과 지속시간
	private float effect_counter = 0f;          // 코루틴 사용시 굳이 사용안해도됨 (Update 함수용)

	private float SkillUseTime = 0f;   //사용지속시간
	private float SkillReuseTime = 0f;  //재사용시간
	private AudioSource SkillSound = null;   //소리
	protected bool IsEffected = false;

	//skillEndCondition variable
	private float SkillTimeOver;  //시간종료

#region Virtual Methods
	protected virtual bool canCancel()          // 일정 조건에서 스킬해제
	{
		return false;
	}			
	protected virtual void giveEffect()         // 스킬 효과 부여
	{
	
	}		
	protected virtual void removeEffect(){	//In Subclass, Must use base.removeEffect();  스킬 효과 제거
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
	protected void CheckSkillEffectforUpdate(){				// 스킬 유효시간 (스킬이 유지되고 있는지 아닌지)
		if(true){ //Condition means a state that effect is on
			effect_counter += Time.deltaTime;
			if(canCancel()||(effect_counter<=EffctTime))
				removeEffect();
		}
	}

	//타플레이어 아이템 사용시
	void OnCollisionEnter(Collision ObjectColiisionSkillEnd)   //충돌시 스킬 해제
    {
		if (ObjectColiisionSkillEnd.gameObject.name == "팥")		// 팥에 맞았을 경우 '도', '모' 스킬 해제
        {

        }
    }

	void OnTriggerEnter(Collider ObjectColiisionSkillEnd)
    {
		if (ObjectColiisionSkillEnd.gameObject.name == "팥")     // 팥에 맞았을 경우 '도', '모' 스킬 해제
		{

        }
    }
};