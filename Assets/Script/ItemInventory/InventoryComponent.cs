using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InventoryComponent : MonoBehaviourPunCallbacks
{
    public List<SlotDataSystem> slots = new List<SlotDataSystem>();
    private int maxSlot = 3;
    public GameObject slotPrefab;

    private void Start()
    {
        GameObject slotPanel = GameObject.Find("InventoryUI");

        for(int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotDataSystem slot = new SlotDataSystem();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateItem(0);
                Debug.LogWarning("input 1");
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateItem(1);
                Debug.LogWarning("input 2");
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateItem(2);
                Debug.LogWarning("input 3");
            }
        }
    }

    private void ActivateItem(int index)
    {
        if (!slots[index].isEmpty)
        {
            slots[index].isEmpty = true;
            GameObject temp = slots[index].slotObj.transform.GetChild(0).gameObject;
            Vector3 characterPosition = transform.position;
            if(temp != null)
            {
                temp.BroadcastMessage("Fire", characterPosition);
            }
        }
    }
}
