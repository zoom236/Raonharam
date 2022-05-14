using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBase : MonoBehaviour
{
    public Text CoolTime_Text;                  // ���� �ð� ǥ��(Text)
    public Image CoolTime_Image;                // ���� �ð� ǥ��(Image)
    private float time_cooltime = 30;           // ��Ÿ�� �ð�
    private float time_current;                 // ��ų ������� �����ð�
    private float time_start;                   // time_current�� ����� ���� �ð�����
    private bool isEnded = true;                // ��Ÿ�� ������ ��

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

    private void Check_CoolTime()                   // ��ų ������� ���� �ð� �˻�
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

    private void End_CoolTime()                     // ��Ÿ���� ���� ��ų ������ �������� ����
    {
        Set_FillAmount(0);
        isEnded = true;
        CoolTime_Text.gameObject.SetActive(false);
        Debug.Log("Skills Available!");
    }

    private void Trigger_Skill()                    // ��ų �ߵ�
    {
        if (!isEnded)
        {
            Debug.LogError("Hold On");
            return;
        }

        Reset_CoolTime();
        Debug.LogError("Trigger_Skill!");
    }

    private void Reset_CoolTime()                   // ��Ÿ�� ����
    {
        CoolTime_Text.gameObject.SetActive(true);
        time_current = time_cooltime;
        time_start = Time.time;
        Set_FillAmount(time_cooltime);
        isEnded = false;
    }
    private void Set_FillAmount(float _value)       // ��ų ���� �ð� Textǥ��
    {
        CoolTime_Image.fillAmount = _value / time_cooltime;
        string txt = _value.ToString("0");
        CoolTime_Text.text = txt;
        Debug.Log(txt);
    }
}
