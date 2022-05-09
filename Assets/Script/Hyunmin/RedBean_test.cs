using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBean_test : MonoBehaviour
{
    public GameObject meshObj;   
    public GameObject effectObj;
    public Rigidbody rigid;

    //�ῡ �ʿ��� �Ž� ������Ʈ�� ȿ�� ������Ʈ,  ���� ȿ��

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosions());
            //�ڷ�ƾ�� �׻� ����Ǵ� ���� �ƴ϶� �ʿ��� ��Ȳ������ �߻�
            //�� ������ ����Ǵ� ���� �ٿ��� ȿ�������� ��ǻ�� �ڿ� ��� ����
    }

    IEnumerator Explosions()
    //�ڷ�ƾ�� IEnumerator�� ��ȯ
    {
        yield return new WaitForSeconds(3f);  //3�ʵ� ����
        rigid.velocity = Vector3.zero;   //rigid�� �ӵ�
        rigid.angularVelocity = Vector3.zero;   // ���ӵ�
        meshObj.SetActive(false);   
        effectObj.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 10, Vector3.up, 0f, LayerMask.GetMask("Enemy"));


        foreach(RaycastHit hitObj in rayHits)  //�迭 ����
            
        {
            hitObj.transform.GetComponent<Enemy>().HitByRedBean(transform.position);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
