using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBean_test : MonoBehaviour
{
    public GameObject meshObj;   
    public GameObject effectObj;
    public Rigidbody rigid;

    //콩에 필요한 매쉬 오브젝트와 효과 오브젝트,  물리 효과

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosions());
            //코루틴은 항상 실행되는 것이 아니라 필요한 상황에서만 발생
            //매 프레임 연산되는 양을 줄여서 효율적으로 컴퓨터 자원 사용 가능
    }

    IEnumerator Explosions()
    //코루틴은 IEnumerator로 반환
    {
        yield return new WaitForSeconds(3f);  //3초뒤 실행
        rigid.velocity = Vector3.zero;   //rigid의 속도
        rigid.angularVelocity = Vector3.zero;   // 각속도
        meshObj.SetActive(false);   
        effectObj.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 10, Vector3.up, 0f, LayerMask.GetMask("Enemy"));


        foreach(RaycastHit hitObj in rayHits)  //배열 포문
            
        {
            hitObj.transform.GetComponent<Enemy>().HitByRedBean(transform.position);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
