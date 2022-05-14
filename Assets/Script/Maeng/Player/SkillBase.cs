using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SkillBase : MonoBehaviourPunCallbacks, IPunObservable
{
    public Text CoolTime_Text;                  // ���� �ð� ǥ��(Text)
    public Image CoolTime_Image;                // ���� �ð� ǥ��(Image)
    protected float time_cooltime = 30;           // ��Ÿ�� �ð�
    protected bool isEnable = true;                // ��Ÿ�� ������ ��
    private float counting;
#region  IPunObservable Methods
   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
       if(stream.IsWriting){  //Warn. Careful Order;
           //To Send
           //ex> stream.SendNext;
       }else{
           //To Receieve
           //ex> var = (type)stream.ReceiveNext();
       }
   }
#endregion
    void Start(){
        counting = 0f;
    }
    void Update(){
        if(Input.GetKey(KeyCode.Space))
        Trigger_Skill();

        if (!isEnable){
            counting += Time.deltaTime;
            if(counting >= time_cooltime){
                counting = 0f;
                SetCanUsable(true);
            }
            Set_FillAmount(time_cooltime - counting);
        }
    }
    [PunRPC]
    public virtual bool Trigger_Skill(){
        SetCanUsable(false);
        return false;}

    protected void SetCanUsable(bool isEnable){
        this.isEnable = isEnable;
        CoolTime_Text.gameObject.SetActive(!isEnable);
        CoolTime_Image.gameObject.SetActive(!isEnable);
    }
    private void Set_FillAmount(float _value)       // ��ų ���� �ð� Textǥ��
    {
        CoolTime_Image.fillAmount = _value / time_cooltime;
        string txt = _value.ToString("0");
        CoolTime_Text.text = txt;
        Debug.Log(txt);
    }
}
