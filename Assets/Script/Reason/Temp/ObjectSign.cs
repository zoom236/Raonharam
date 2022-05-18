using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSign : MonoBehaviour
{
    public float lifetime = 1f;
   private void OnEnable() {
       StartCoroutine("Disappear");
   }
   IEnumerator Disappear(){
       yield return new WaitForSecondsRealtime(lifetime);
       gameObject.SetActive(false);
   }
}
