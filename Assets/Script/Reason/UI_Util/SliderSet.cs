using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSet : MonoBehaviour
{
    public float Value;
    [SerializeField]
    Slider Slider;
    [SerializeField]
    Button UPButton;
    [SerializeField]
    Button DownButton;
    [SerializeField]
    InputField Input;
    public bool isInteger;
    public float InitialValue;
    public int Min;
    public int Max;
    public Action<float> OnValueChange;
#region MonoBehaviour Callbacks
    void Awake() => OnValueChange = SetUI;
    void Start(){
        if(Input == null)Debug.Log("InputField Object is Empty");
        else{
            if(isInteger)
                Input.contentType = InputField.ContentType.IntegerNumber;
            else
                Input.contentType = InputField.ContentType.DecimalNumber;
        }
        if(Slider == null) Debug.Log("Slider Object is Empty");
        else{
            Slider.minValue = Min;
            Slider.maxValue = Max;
            Slider.wholeNumbers = isInteger;
        }
        if(UPButton == null) Debug.Log("UPButton Object is Empty");
        if(DownButton == null) Debug.Log("DownButton Object is Empty");

        SetValue(Value);
        Input?.onEndEdit.AddListener((value)=>SetValue(float.Parse(value)));
        Slider?.onValueChanged.AddListener((value)=>SetValue(value));
        UPButton?.onClick.AddListener(AddValue);
        DownButton?.onClick.AddListener(SubValue);
    }
#endregion
    void AddValue() => SetValue(Value + (isInteger ? 1 :0.1f));
    void SubValue()=> SetValue(Value - (isInteger ? 1 :0.1f));
    void SetUI(float value){
        if(Slider!=null){
            Slider.value = Value;
            Debug.Log($"Slider Value: {Slider.value}");
        }
        if(Input!=null){
            Input.text = Value.ToString();
        }
    }
    void SetValue(float value){
        if(value<Min)
            Input.text = Min.ToString();
        if(value>Max)
            Input.text = Max.ToString();
        float clampedvalue = Mathf.Clamp(value,Min,Max);
        if(!Mathf.Approximately(Value,clampedvalue)){
            Value = isInteger ? Mathf.RoundToInt(clampedvalue) : (float)System.Math.Round(clampedvalue,1);
            OnValueChange(Value);
        }
    }
    public void ResetMax(float value){
        if(Slider!=null){
            Slider.maxValue = value;
        }
    }
}
