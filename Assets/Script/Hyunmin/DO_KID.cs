using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DO_KID : ContinuousSkill
{
    [SerializeField]
    private GameObject COBJ;   //������ ������ ���� ������Ʈ

    private Renderer _renderPlayer;

    [SerializeField]
    private GameObject Doki_changeimpact;
    public Material[] material;



    // Start is called before the first frame update
    void Start()
    {
        _renderPlayer = GetComponent<Renderer>();
       // _renderPlayer.enabled = true;

        // StartCoroutine(ChangePlayerSt());
        //for(int i = 0; i < transform.childCount; i++)
        {
            //characterList[i] = transform.GetChild(i).gameObject;

        }


    }

    // Update is called once per frame
    void Update()
    {
        //ContinuousSkill ������Ʈ �ȿ� ContinuousSkill ��ũ��Ʈ �����´�.
        // continuousSkill = GameObject.Find("ContinuousSkill").GetComponent<ContinuousSkill>();

        if (photonView.IsMine)    //����
        {
            if (Input.GetKeyDown(KeyCode.X))
            {

                Debug.Log("������ ����");
                Doki_changeimpact.SetActive(false);
                DokiChange();
                // PlayerChange(); //������ ����
                StartCoroutine(kidChange());



            }

            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    Debug.Log("���� ����");
            //    COBJ.SetActive(false);
            //    _renderPlayer.sharedMaterial = material[1];
            //    changeimpact.SetActive(false);
            //}
        }



        // if (PV.IsMine)
        //{
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        characterList[0].SetActive(true);



        //        Debug.Log("�۵�");

        //        effectOJT.SetActive(true);


        //    }
        //}

    }

    IEnumerator kidChange()   //����  ����
    {
        yield return new WaitForSeconds(2f);
        _renderPlayer.sharedMaterial = material[1];
        COBJ.SetActive(false);
        Doki_changeimpact.SetActive(true);


    }
    void DokiChange()
    {
        COBJ.SetActive(true);
        _renderPlayer.sharedMaterial = material[0];


    }


    void OnTriggerEnter(Collider ObjectColiisionSkillEnd)     //������ �浹 ��?
    {
        if (ObjectColiisionSkillEnd.tag == "Red bean")
        {
            //event
            StopCoroutine(kidChange());



        }


    }




}
