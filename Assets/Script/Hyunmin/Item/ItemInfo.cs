using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInfo : ScriptableObject
//scriptableobject를 사용하여 간단하게 많은 양의 프리팹들에 정보를 넣을 수 있다.
{

    //데이터를 저장하는데 사용할 수 있는 데이터 컨테이너
    //불러올때마다 사본이 생성되는 것을 방지하여 메모리 사용을 줄임
    //프리팹이 있는 프로젝트의 경우 유용함 메모리에 데이터 사본을 하나만 저장

    public string itemName;

}
