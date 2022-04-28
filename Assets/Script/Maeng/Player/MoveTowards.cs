using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    /* ���� �������� �̵��ϴ� ��ũ��Ʈ�Դϴ�. */

    public Camera cam; //����ī�޶�
    private float Speed = 0.5f; // �̵��ӵ�

    void Start()
    {
    }

    void Update()
    {
        MoveLookAt();
    }
    void MoveLookAt()
    {
        //����ī�޶� �ٶ󺸴� �����Դϴ�.
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        //ī�޶� �ٶ󺸴� �������� �Ѹǵ� �ٶ󺸰� �մϴ�.
        transform.localRotation = cam.transform.localRotation;
        //�Ѹ��� Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� �������־����ϴ�.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //�ٶ󺸴� ���� �������� �̵��մϴ�.
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    }
}
