using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<SlotCheck>().num + 1).ToString())
        {
            // ������ ���
            Debug.Log("Smoke , slotNumber : " + (transform.parent.GetComponent<SlotCheck>().num + 1));
            Destroy(this.gameObject);
        }
    }
}
