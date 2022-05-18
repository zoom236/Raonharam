using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContinuousSkill: SkillBase{
	protected float EffctTime = 1f;
	private float effect_counter = 0f;

	private float SkillUseTime = 0f;   //������ӽð�
	private float SkillReuseTime = 0f;  //����ð�
	private AudioSource SkillSound = null;   //�Ҹ�

	//skillEndCondition variable
	private float SkillTimeOver;  //�ð�����

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

	public void ChildAbility()   //���̴ɷ�
    {

    }

	public void DokiAbility() //������ �ɷ�
    {

    }

	public void SkillEndCondition() //��ų��������
    {

    }

	//Ÿ�÷��̾� ������ ����
	void OnCollisionEnter(Collision ObjectColiisionSkillEnd)   //�浹�� ��ų ����
    {

    }

	void OnTriggerEnter(Collider ObjectColiisionSkillEnd)
    {

    }
};