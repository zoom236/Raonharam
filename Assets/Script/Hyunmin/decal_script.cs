using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decal_script : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject decalPrefab;   //데칼 프리팹 생ㅅㅇ

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))   //마우스 0번 눌렀을 때
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
        decal.transform.rotation = Quaternion.identity; //회전 없음
    }
}

