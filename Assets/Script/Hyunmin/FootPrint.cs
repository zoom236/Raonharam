using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    [Tooltip("this is how long the decal will stay, before it shrinks away totally")]
    //이것은 데칼이 완전히 줄어들기 전에 데칼이 유지되는 기간.
    public float Lifetime = 2.0f;   

    private float mark;   
    private Vector3 OrigSize;  

    public void Start()
    {
        mark = Time.time;
        OrigSize = this.transform.localScale;
    }
    public void Update()
    {
        float ElapsedTime = Time.time - mark;
        if (ElapsedTime != 0)
        {
            float PercentTimeLeft = (Lifetime - ElapsedTime) / Lifetime;

            this.transform.localScale = new Vector3(OrigSize.x * PercentTimeLeft, OrigSize.y * PercentTimeLeft, OrigSize.z * PercentTimeLeft);
            if (ElapsedTime > Lifetime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
