using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListitemmanagement : MonoBehaviour
{


    public GameObject contents;

    public GameObject uiListItemPrefab;
    public GameObject uiListItemPrefab2;
    public GameObject uiListItemPrefab3;
    public int itemSlot;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <itemSlot; i++)
        {
            // if(i==0)    //ù��° ������
            //  {    Instantiate<GameObject>(this.uiListItemPrefab, contents.transform);  }  else{}    //i�� 0�� �� ����. ������ �����ؼ� ���� ������ �߰�




            Instantiate<GameObject>(this.uiListItemPrefab, contents.transform);
        }
    }

    // Update is called once per frame
 
}
