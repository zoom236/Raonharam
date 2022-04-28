using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    //private float range;  // ������ ������ ������ �ִ� �Ÿ�

    public bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    public RaycastHit hitInfo;  // �浹ü ���� ����
    public Inventory inven;
    

    //[SerializeField]
    //private LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.


    [SerializeField]
    public Text actionText;  // �ൿ�� ���� �� �ؽ�Ʈ

    GameObject book;

   



    public void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ŭ��");
            //CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem()
    {
        //Debug.DrawRay(transform.position, transform.forward * range, Color.blue);
        //if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))

        /*Debug.Log("������ Ȯ��");
        if (hitInfo.transform.tag == "Item")
        {
            ItemInfoAppear();
        }
        else
            ItemInfoDisappear();*/
    }

    public void ItemInfoAppear()
    {
        Debug.Log("������ ã��!");
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        TryAction();
        //actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� " + "<color=yellow>" + "(E)" + "</color>";
    }

    public void ItemInfoDisappear()
    {
        Debug.Log("pickupActivated ��������!");
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        Debug.Log("EŰ ����");
        if (pickupActivated)
        {
            Debug.Log("������ ȹ��");  // �κ��丮 �ֱ�

            Destroy(GameObject.FindGameObjectWithTag("Item"));
            ItemInfoDisappear();
        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("�浹");
        if (other.gameObject == book)
        {
            Debug.Log("������ Ȯ��");
            ItemInfoAppear();
        }
        else
            ItemInfoDisappear();
    }*/
}

