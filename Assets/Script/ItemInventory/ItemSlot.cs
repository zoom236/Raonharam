using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ItemSlot : MonoBehaviourPunCallbacks
{
    InventoryComponent inventory;
    public int num;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryComponent>();
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.slots[num].isEmpty = true;
        }
    }
}
