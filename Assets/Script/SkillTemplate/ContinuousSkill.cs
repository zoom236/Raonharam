using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContinuousSkill: SkillBase{
	protected float EffctTime = 1f;             // ȿ�� ���ӽð�
	private float effect_counter = 0f;          // �ڷ�ƾ ���� ���� �����ص��� (Update �Լ���)

	private float SkillUseTime = 0f;   //������ӽð�
	private float SkillReuseTime = 0f;  //����ð�
	private AudioSource SkillSound = null;   //�Ҹ�
	protected bool IsEffected = false;

	//skillEndCondition variable
	private float SkillTimeOver;  //�ð�����

#region Virtual Methods
	protected virtual bool canCancel()          // ���� ���ǿ��� ��ų����
	{
		return false;
	}			
	protected virtual void giveEffect()         // ��ų ȿ�� �ο�
	{
	
	}		
	protected virtual void removeEffect(){	//In Subclass, Must use base.removeEffect();  ��ų ȿ�� ����
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
	protected void CheckSkillEffectforUpdate(){				// ��ų ��ȿ�ð� (��ų�� �����ǰ� �ִ��� �ƴ���)
		if(true){ //Condition means a state that effect is on
			effect_counter += Time.deltaTime;
			if(canCancel()||(effect_counter<=EffctTime))
				removeEffect();
		}
	}

	//Ÿ�÷��̾� ������ ����
	void OnCollisionEnter(Collision ObjectColiisionSkillEnd)   //�浹�� ��ų ����
    {
		if (ObjectColiisionSkillEnd.gameObject.name == "��")		// �Ͽ� �¾��� ��� '��', '��' ��ų ����
        {

        }
    }

	void OnTriggerEnter(Collider ObjectColiisionSkillEnd)
    {
		if (ObjectColiisionSkillEnd.gameObject.name == "��")     // �Ͽ� �¾��� ��� '��', '��' ��ų ����
		{

        }
    }
};