using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemthrowpo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //���۰� ���ÿ� ��ü�� �߶����� �ʵ��� �ϱ� ���� �ڵ�
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("1");
        }
    }

    void Shoot()
    {
        Vector3 speed = new Vector3((float)3.11, (float)4.84, (float)-26.13);
        GetComponent<Rigidbody>().AddForce(speed);
    }
}
