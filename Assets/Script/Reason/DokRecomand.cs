using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SliderSet))]
public class DokRecomand : MonoBehaviour
{
    //Function : User can set Dokkebi Number Additional Option
    [SerializeField]
    SliderSet Player;
    SliderSet slider;
    void Start(){
        Player.OnValueChange += setDokkebiMax;
        slider = GetComponent<SliderSet>();
    }
    void setDokkebiMax(float value){
        if(slider != null){
            slider.ResetMax(Player.Value - 1);
            Debug.Log($"DokkebiMax : {value}");
        }
    }
}
