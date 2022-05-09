using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decal_script : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject decalPrefab;   //��Į ������ ������

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))   //���콺 0�� ������ ��
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hitInfo))
            {
                SpawnDecal(hitInfo);

            }
        }
    }

    private void SpawnDecal(RaycastHit hitInfo)
    {
        var decal = Instantiate(decalPrefab);
        decal.transform.position = hitInfo.point;
        decal.transform.forward = hitInfo.normal * -1f;
        decal.transform.rotation = Quaternion.identity; //ȸ�� ����
    }
}

