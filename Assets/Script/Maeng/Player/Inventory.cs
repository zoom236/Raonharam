using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnSlotCountChage(int val);
    public OnSlotCountChage onSlotCountChange;

    public delegate void OnChangeItem();  // �κ��丮 ui �ٲ��
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();  // ȹ���� �������� ���� ����Ʈ

    private int slotCnt;
    public int SlotCnt
    {
        get=>slotCnt;
        set
        {
            slotCnt = value;
            //onSlotCountChange.Invoke(slotCnt);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SlotCnt = 5;
    }

    public bool AddItem(Item _item)  //items ����Ʈ�� �������� �߰��� �� �ִ� �޼���
    {
        if (items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            
            onChangeItem.Invoke();
            return true;  // ������ �߰��� �����ϸ�
        }
        return false;
        // items�� ������ slotCnt (���� Ȱ�� ����)���� ���� ���� ������ �߰��� �� �ֵ���
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            Debug.Log("�浹");

            FieldItem fieldItems = collision.GetComponent<FieldItem>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem();
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
