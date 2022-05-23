using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DO_DOKI : ContinuousSkill
{

    [SerializeField]
    private GameObject DKOBJ;  //아이 변신을 위해 오브젝트

    private Renderer _renderPlayer2;

    [SerializeField]
    private GameObject kid_changeimpact;
    [SerializeField]
    private GameObject bat;

    public Material[] kid_material;


    // Start is called before the first frame update
    void Start()
    {
        _renderPlayer2 = GetComponent<Renderer>();
        //_renderPlayer2.enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)//아이 변신
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("아이 변신");
                kid_change();
                StartCoroutine(DokiChange());

            }


        }

    }
    IEnumerator DokiChange()   //아이  변신
    {
        yield return new WaitForSeconds(3f);
        _renderPlayer2.sharedMaterial = kid_material[1];
        DKOBJ.SetActive(true);
        kid_changeimpact.SetActive(true);

    }

        void kid_change()
    {
        DKOBJ.SetActive(false);
        kid_changeimpact.SetActive(false);
        bat.SetActive(false);
        _renderPlayer2.sharedMaterial = kid_material[0];
    }

}
