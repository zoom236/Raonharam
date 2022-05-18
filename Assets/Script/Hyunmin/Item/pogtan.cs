using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pogtan : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public Rigidbody rigid;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion());
        effectObj.SetActive(false);
    }

    // Update is called once per frame
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        meshObj.SetActive(false);
        effectObj.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 10, Vector3.up, 0f, LayerMask.GetMask("Enemy"));


    }


    void Update()
    {

    }
}
