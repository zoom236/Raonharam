using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeScript : MonoBehaviour
{

    Scrollbar bar;    //��ũ�ѹ� bar ����


    // Start is called before the first frame update
    void Start()
    {
        bar = gameObject.GetComponent<Scrollbar>();     // ������ ���� ������Ʈ scrollbar ������
        bar.value = 1;     // bar�� 1 ����

    }

    // Update is called once per frame
    void SetContentSize()

    {
        //SettingPanel.GetComponent().relativePositionOnReset = new Vector2(0, 0); 
    }
}


