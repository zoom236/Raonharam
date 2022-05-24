using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ItemBase : MonoBehaviourPunCallbacks
{
    public GameObject slotItem;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag.Equals("Player"))
        {
            InventoryComponent inven = collision.GetComponent<InventoryComponent>();
            for(int i = 0; i < inven.slots.Count; i++)
            {
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
