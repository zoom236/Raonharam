using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject Roulette;   // ������ ���ư� �귿��
    public Transform Needle;   //�Ÿ��� Ȯ���ϱ� ���� �ٴ�
    public GameObject[] DisplayMapScene;

    List<int> StartList = new List<int>();    //���� �̱⸦ ���� ����Ʈ
    
    int MapCnt = 8;



    void Start()
    {
        for (int i = 0; i < MapCnt; i++)
        {
            StartList.Add(i);               //

        }

        for (int i = 0; i < MapCnt; i++)
        {
            int randomIndex = Random.Range(0, StartList.Count);          //
            
            StartList.RemoveAt(randomIndex);

        }


    }

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartRoulette());
        }

    }
    IEnumerator StartRoulette()
    {

        yield return new WaitForSeconds(2f);

        float randomSpd = Random.Range(1.0f, 5.0f);
        float rotateSpeed = 100f * randomSpd;// ȸ�� �ӵ� �ʱⰪ

        
            while (true)
            {
                yield return null;
                if (rotateSpeed <= 0.01f) break;  //���� rotatespeed�� 0.01�����̸� ����

                rotateSpeed = Mathf.Lerp(rotateSpeed, 0, Time.deltaTime * 2f);    //while������ rotatespeed�� Lerp�Լ��� ���δ�
                Roulette.transform.Rotate(0, 0, rotateSpeed);  //z�� ȸ��
            }
            yield return new WaitForSeconds(1f);
            Result();
        
    }

     void Result()
    {
        float closetIndex = 0;
        float closetDis = 500f;
        float currentDis = 0f;

        for(int i = 0; i < MapCnt; i++)
        {
            currentDis = Vector2.Distance(DisplayMapScene[i].transform.position, Needle.position);
            if(closetDis > currentDis)
            {
                closetDis = currentDis;
                closetIndex = i;
            }
        }

        Debug.Log("��÷" + closetIndex);

    }

}

//   void Update()
//  {

// transform.Rotate(0, 0, rotationSpeed);  // ȸ�� �ӵ���ŭ �귿�� ȸ��
// rotationSpeed *= 0.996f;     //�귿�� ���ӽ�Ų��.
//List<int> ResultIndexList = new List<int>(); // ��� ���� ������ ����Ʈ
//ResultIndexList.Add(StartList[randomIndex]);
// if (Input.GetMouseButtonDown(0))    //Ŭ���ϸ� ȸ�� �ӵ��� ����
// {
//  rotationSpeed = 10;
// }



/// }
//}
