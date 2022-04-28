using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotNew : MonoBehaviour
{
    public Image RedBean;       // ��
    public Image Zipshoes;      // ¤��
    public Image Amulet;        // ����
    public Image Got;           // ��
    public Image StickySlime;   // ������
    public Image SmokeBomb;     // ����ź
    public Image BeanBomb;      // ���ź
    public Image GasTrap;       // �汸Ʈ��

    public Image RedBean2;       // ��
    public Image Zipshoes2;      // ¤��
    public Image Amulet2;        // ����
    public Image Got2;           // ��
    public Image StickySlime2;   // ������
    public Image SmokeBomb2;     // ����ź
    public Image BeanBomb2;      // ���ź
    public Image GasTrap2;       // �汸Ʈ��

    public Image RedBean3;       // ��
    public Image Zipshoes3;      // ¤��
    public Image Amulet3;        // ����
    public Image Got3;           // ��
    public Image StickySlime3;   // ������
    public Image SmokeBomb3;     // ����ź
    public Image BeanBomb3;      // ���ź
    public Image GasTrap3;       // �汸Ʈ��


    string[] inven = new string[3];       // �κ��丮 3ĭ �迭

    private ItemNew index;

    int num = 0;
    string ItemName;

    [SerializeField] Text pickUpText;
    bool isPickUp;

    void Start()
    {
        
    }

    void Update()
    {
        ItemUse();

        
    }

    //void ItemSwitch()
    //{
    //    switch(index.Index)
    //    {
    //        case 1:
    //            RedBean.gameObject.SetActive(true);
    //            break;
    //    }
    //}

    void AddInven()
    {
        for (int i = 0; i < 3; i++)
        {
            if (inven[i] == null)
            {
                inven[i] = ItemName;
            }


            else
            {
                return;
            }
        }
    }

    void ItemUse()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inven[0] = null;
            //�ش� �̹��� ��Ȱ��ȭ
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inven[1] = null;
        }

        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            inven[2] = null;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedBean"))
        {
            //Debug.Log("�浹");
            num = 1;
        }

        else if (collision.gameObject.CompareTag("ZipShoes"))
        {
            //Debug.Log("�浹");
            num = 2;
        }

        else if (collision.gameObject.CompareTag("Amulet"))
        {
            //Debug.Log("�浹");
            num = 3;
        }

        else if (collision.gameObject.CompareTag("Got"))
        {
            //Debug.Log("�浹");
            num = 4;
        }

        else if (collision.gameObject.CompareTag("StickySlime"))
        {
            //Debug.Log("�浹");
            num = 5;
        }

        else if (collision.gameObject.CompareTag("SmokeBomb"))
        {
            //Debug.Log("�浹");
            num = 6;
        }

        else if (collision.gameObject.CompareTag("BeanBomb"))
        {
            //Debug.Log("�浹");
            num = 7;
        }

        else if (collision.gameObject.CompareTag("GasTrap"))
        {
            //Debug.Log("�浹");
            num = 8;
        }

        switch (num)
        {
            case 1:
                RedBean.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "RedBean";
                AddInven();
                break;
            case 2:
                Zipshoes.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "Zipshoes";
                AddInven();
                break;
            case 3:
                Amulet.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "Amulet";
                AddInven();
                break;
            case 4:
                Got.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "Got";
                AddInven();
                break;
            case 5:
                StickySlime.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "StickySlime";
                AddInven();
                break;
            case 6:
                SmokeBomb.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "SmokeBomb";
                AddInven();
                break;
            case 7:
                BeanBomb.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "BeanBomb";
                AddInven();
                break;
            case 8:
                GasTrap.gameObject.SetActive(true);     // �̹��� Ȱ��ȭ
                ItemName = "GasTrap";
                AddInven();
                break;
        }
    }
}
