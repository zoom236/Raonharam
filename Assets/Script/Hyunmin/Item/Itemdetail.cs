using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Itemdetail : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemInfo itemInfo;
    public GameObject itemGameObject;



    public abstract void Use();
    //추상 함수 선언
}
