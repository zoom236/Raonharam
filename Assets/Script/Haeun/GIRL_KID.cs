using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

//using playerMoveMent = PlayerMovement

public class GIRL_KID : ContinuousSkill
{

    PlayerMovement player1;
    public ParticleSystem ps;

    public float LimitTimer;
    public Text text_Timer;

    float originSpeed; 
    float speedEffect = 1.25f; // ¤�� �ɷ� 
    float IsDirtRoadEffect = 0.5f; //���
    bool IsDirtRoad = false;
    bool IsUseSkill = false; //��ų��뿩�� 
    
    void Start()
    {
        
        player1 = gameObject.GetComponent<PlayerMovement>();
        originSpeed = player1.speed;
        ps = GetComponentInChildren<ParticleSystem>();

        ps.Stop();
        EffctTime = 15f;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SkillFire();
            }
        }

    }

    protected override void giveEffect()
    {
        IsEffected = true;
        ps.Play();
        Debug.Log("������");
        if (IsDirtRoad)
        {
            player1.speed = originSpeed * speedEffect * IsDirtRoadEffect;
            Debug.Log("speed : " + player1.speed);
        }
        else
        {
            player1.speed = originSpeed * speedEffect;
            Debug.Log("false speed : " + player1.speed);
        }
        StartCoroutine(routine());    
    }

    public virtual void removeEffect()
    {
        //Ÿ �÷��̾� ������ ��� ������ ������ �� 
        player1.speed = originSpeed;


        //�ð��� �� ������ ��� 
        ps.Stop();
        IsEffected = false;
        
    }

    //�ڷ�ƾ�� �Լ� 
    private IEnumerator routine()
    {
        yield return new WaitForSeconds(EffctTime);
        removeEffect();
    }

    protected override bool isEffectiveness()
    {  
        return isEnable || IsEffected;
    }
}
