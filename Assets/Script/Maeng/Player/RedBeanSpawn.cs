using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBeanSpawn : MonoBehaviour
{
    public GameObject RedBeanObj;       // �� ������ ����
    public GameObject Spawn;     // �� ���� ��ġ
    public Camera followCamera;         // ����� ī�޶�
    public GameObject player;
    RedBeanItem bean;

    public bool RedBeanUse;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Drop();
    }

    void Drop()
    {
        Debug.DrawRay(Spawn.transform.position, Spawn.transform.forward * 100f, Color.red);

        if (Input.GetKeyDown(KeyCode.H))
        {
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            int floorMask = LayerMask.GetMask("Floor");

            if (Physics.Raycast(ray, out rayhit, 100, floorMask))
            {
                Vector3 nextVec = rayhit.point - player.transform.position;
                nextVec.y = 6;

                GameObject instantRedBean = Instantiate(RedBeanObj, transform.position, transform.rotation);
                Rigidbody rigidBean = instantRedBean.GetComponent<Rigidbody>();
                rigidBean.AddForce(nextVec, ForceMode.Impulse);



                RedBeanUse = true;
                Debug.Log(RedBeanUse);
            }
        }
        RedBeanUse = false;
        Debug.Log(RedBeanUse);
    }
}
