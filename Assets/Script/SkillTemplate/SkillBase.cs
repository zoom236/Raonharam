using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SkillBase : MonoBehaviourPunCallbacks
{
    public Text CoolTime_Text;                  // ���� �ð� ǥ��(Text)
    public Image CoolTime_Image;                // ���� �ð� ǥ��(Image)
    protected float time_cooltime = 30;           // ��Ÿ�� �ð�
    protected bool isEnable = true;                // ��Ÿ�� ������ ��
    private float cooltime_counter = 0f;
#region Virtual Methods
    [PunRPC]
    public virtual void SkillFire(){ //In Subclass
        SetCanUsable(false);
    }
    protected virtual bool isEffectiveness(){
        //Effectiveness means player is on a state that can use skill
        return isEnable;
    }
    protected virtual void SkillBaseUpstream(PhotonStream stream){
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
        CoolTime_Text.gameObject.SetActive(!isEnable);
        CoolTime_Image.gameObject.SetActive(!isEnable);
    }
    protected void CheckCoolTimeForUpdate(){
        if (!isEffectiveness()){
            cooltime_counter += Time.deltaTime;
            if(cooltime_counter >= time_cooltime){
                cooltime_counter = 0f;
                SetCanUsable(true);
            }
            Set_FillAmount(time_cooltime - cooltime_counter);
        }
    }
    private void Set_FillAmount(float _value)       // ��ų ���� �ð� Textǥ��
    {
        CoolTime_Image.fillAmount = _value / time_cooltime;
        string txt = _value.ToString("0");
        CoolTime_Text.text = txt;
        Debug.Log(txt);
    }
}
