using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SkillBase : MonoBehaviourPunCallbacks
{
    public Text CoolTime_Text;                  //쿨타임 표시(Text)
    public Image CoolTime_Image;                // 쿨타임 표시(Image)
    protected float time_cooltime = 30;           // 쿨타임 시간
    protected bool isEnable = true; // 쿨타임스킬을 사용할 수 있는 상태 확인
    private bool uiset = false;              
    private float cooltime_counter = 0f;
    private void Awake() {
        Transform SkillCoolSet = GameObject.Find("SkillCoolSet")?.transform;
        if(SkillCoolSet != null){
            Debug.Log("Skill Cool set Found");
            CoolTime_Image = SkillCoolSet.GetChild(0).GetComponent<Image>();
            CoolTime_Text = SkillCoolSet.GetChild(1).GetComponent<Text>();
            uiset = true;
        }
        else
            Debug.Log("Skill Cool set NOT Found");
    }
#region Virtual Methods
    [PunRPC]
    public virtual void SkillFire(){ //In Subclass
        SetCanUsable(false);
    }
    protected virtual bool isEffectiveness(){   //스킬을 사용할 수 있는지 없는지
        //Effectiveness means player is on a state that can use skill
        return isEnable;
    }
    protected virtual void SkillBaseUpstream(PhotonStream stream){    //서버에 동기화시킬려면 포톤 
        //Must be Add super(stream); And, Last SkillBaseUpstream must be called in on OnPhotonSerializeView
        stream.SendNext(isEnable);
        stream.SendNext(time_cooltime);
    }
    protected virtual void SkillBaseDownstream(PhotonStream stream){
        //Must be Add super(stream); And, Last SkillBaseDownstream must be called in on OnPhotonSerializeView
        isEnable = (bool)stream.ReceiveNext();
        time_cooltime = (float)stream.ReceiveNext();
    }
#endregion
    protected void SetCanUsable(bool isEnable){
        this.isEnable = isEnable;
        if(!uiset) return;
        CoolTime_Text.gameObject.SetActive(!isEnable);
        CoolTime_Image.gameObject.SetActive(!isEnable);
    }


    //쿨타임 시간 체크
    protected void CheckCoolTimeForUpdate(){
        if (!isEffectiveness()){
            cooltime_counter += Time.deltaTime;
            if(cooltime_counter >= time_cooltime){
                cooltime_counter = 0f;
                SetCanUsable(true);
            }
            if(uiset)
                Set_FillAmount(time_cooltime - cooltime_counter);
        }
    }
    private void Set_FillAmount(float _value)       // 스킬 재사용 시간 시각화
    {
        CoolTime_Image.fillAmount = _value / time_cooltime;
        string txt = _value.ToString("0");
        CoolTime_Text.text = txt;
        Debug.Log(txt);
    }
}
