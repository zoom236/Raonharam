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
    float speedEffect = 1.25f; // 짚신 능력 
    float IsDirtRoadEffect = 0.5f; //흙길
    bool IsDirtRoad = false;
    bool IsUseSkill = false; //스킬사용여부 
    
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

    public override void giveEffect()
    {
        IsEffected = true;
        ps.Play();
        Debug.Log("찍히나");
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
        //타 플레이어 아이템 사용 범위에 들어왔을 때 
        player1.speed = originSpeed;


        //시간이 다 끝났을 경우 
        ps.Stop();
        IsEffected = false;
        
    }

    //코루틴용 함수 
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
