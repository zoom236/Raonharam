using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;  // � �������ΰ�?
    public MeshRenderer image; // �������̶� �´� �̹��� �ֱ�

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;  // ������ �̸�
        item.itemImage = _item.itemImage;   // �ش� ������Ʈ�� �̹���
        item.itemType = _item.itemType;  // �Ҹ�ǰ���� �������

        //image.material = _item.itemMaterial;
    }

    public Item GetItem()  // ������ ȹ��
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
