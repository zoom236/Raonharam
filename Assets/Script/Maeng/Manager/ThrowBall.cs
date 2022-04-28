using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{



    public GameObject ballPosition;      //���⸦ �߻��� ��ġ ����

    public GameObject ballFactory;   //���� ������Ʈ


    public float throwPower = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))    //���콺 Ŭ���� �߻�
        {
           
            GameObject ball = Instantiate(ballFactory);
            ball.transform.position = ballPosition.transform.position;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            //ī�޶��� ���� �������� ���⿡ ������ ��

            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);





        }

    }



}
