using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DO_KID : ContinuousSkill
{
    [SerializeField]
    private GameObject COBJ;   //도깨비 변신을 위한 오브젝트

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
        //ContinuousSkill 오브젝트 안에 ContinuousSkill 스크립트 가져온다.
        // continuousSkill = GameObject.Find("ContinuousSkill").GetComponent<ContinuousSkill>();

        if (photonView.IsMine)    //변신
        {
            if (Input.GetKeyDown(KeyCode.X))
            {

                Debug.Log("도깨비 변신");
                Doki_changeimpact.SetActive(false);
                DokiChange();
                // PlayerChange(); //도깨비 변신
                StartCoroutine(kidChange());



            }

            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    Debug.Log("아이 변신");
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



        //        Debug.Log("작동");

        //        effectOJT.SetActive(true);


        //    }
        //}

    }

    IEnumerator kidChange()   //아이  변신
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


    void OnTriggerEnter(Collider ObjectColiisionSkillEnd)     //아이템 충돌 시?
    {
        if (ObjectColiisionSkillEnd.tag == "Red bean")
        {
            //event
            StopCoroutine(kidChange());



        }


    }




}
