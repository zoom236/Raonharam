using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;       // �ִ� HP
    public int curHealth;       // ���� HP

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
    }

    public void HitByRedBean(Vector3 explosionPos)
    {
        curHealth -= 20;
        Vector3 reactVec = transform.position - explosionPos;       // ���ۿ� ���� ���ϱ�
        StartCoroutine(OnDamage(reactVec));
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            mat.color = Color.white;

            reactVec = reactVec.normalized;                 // ���� ���� �ݴ�������� �˹�
            reactVec += Vector3.up;

            rigid.AddForce(reactVec * 3, ForceMode.Impulse);
        }

        else if (curHealth == 0)            // �׾��� ��
        {
            mat.color = Color.gray;
            gameObject.layer = 11;
            Debug.Log("���� �¸�!");

            //Destroy(gameObject, 4);
        }
    }
}
