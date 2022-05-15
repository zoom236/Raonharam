using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtons : MonoBehaviour
{
#region Private Serializable Fields
    [SerializeField]
    private Button publicButton;
    [SerializeField]
    private Button privateButton;
#endregion
    public bool isPublic;
#region MonoBehaviour Callbacks
    void Start(){
        isPublic = true;
        Switch(isPublic);
        publicButton.onClick.AddListener(() => Switch(true));
        privateButton.onClick.AddListener(() => Switch(false));
    }
#endregion
#region Public Methods
    void Switch(bool isPublic){
        this.isPublic = isPublic;
        publicButton.interactable = !isPublic;
        privateButton.interactable = isPublic;
    }
#endregion
}
