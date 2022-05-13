using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    public Text CoolTime_Text;                  // 남은 시간 표시(Text)
    public Image CoolTime_Image;                // 남은 시간 표시(Image)
    private float time_cooltime = 30;           // 쿨타임 시간
    private float time_current;                 // 스킬 재사용까지 남은시간
    private float time_start;                   // time_current를 만들기 위해 시간저장
    private bool isEnded = true;                // 쿨타임 끝났을 때

    void Start()
    {
        Trigger_Skill();
    }

    void Update()
    {
        if (isEnded)
            return;
        Check_CoolTime();
    }

    private void Check_CoolTime()                   // 스킬 재사용까지 남은 시간 검사
    {
        time_current = Time.time - time_start;
        if (time_current < time_cooltime)
        {
            Set_FillAmount(time_cooltime - time_current);
        }
        else if (!isEnded)
        {
            End_CoolTime();
        }
    }

    private void End_CoolTime()                     // 쿨타임이 끝나 스킬 재사용이 가능해진 시점
    {
        Set_FillAmount(0);
        isEnded = true;
        CoolTime_Text.gameObject.SetActive(false);
        Debug.Log("Skills Available!");
    }

    private void Trigger_Skill()                    // 스킬 발동
    {
        if (!isEnded)
        {
            Debug.LogError("Hold On");
            return;
        }

        Reset_CoolTime();
        Debug.LogError("Trigger_Skill!");
    }

    private void Reset_CoolTime()                   // 쿨타임 리셋
    {
        CoolTime_Text.gameObject.SetActive(true);
        time_current = time_cooltime;
        time_start = Time.time;
        Set_FillAmount(time_cooltime);
        isEnded = false;
    }
    private void Set_FillAmount(float _value)       // 스킬 재사용 시간 Text표시
    {
        CoolTime_Image.fillAmount = _value / time_cooltime;
        string txt = _value.ToString("0");
        CoolTime_Text.text = txt;
        Debug.Log(txt);
    }
}
