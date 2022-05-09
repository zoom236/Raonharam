using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_script : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public Rigidbody rigid;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bomb());

    }

    IEnumerator Bomb()
    {
        yield return new WaitForSeconds(3f);
        rigid.velocity = new Vector3(3, 0, 0);
        rigid.angularVelocity = Vector3.zero;
        meshObj.SetActive(false);
        effectObj.SetActive(true);

        RaycastHit[] ray = Physics.SphereCastAll(transform.position,3,Vector3.up,0f,LayerMask.GetMask("Enemy"));
    
        foreach(RaycastHit hitObj in ray)
        {
          //  hitObj.transform.GetComponent<Enemy>().HitByRedBean;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
