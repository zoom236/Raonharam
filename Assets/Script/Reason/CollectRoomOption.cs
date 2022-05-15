using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(LobbyNetworkConnector))]
public class CollectRoomOption : MonoBehaviour
{
    [SerializeField]
    RadioButtons access;
    [SerializeField]
    SliderSet maxplayer;
    [SerializeField]
    SliderSet dokplayer;
    [SerializeField]
    Button trigger;
    LobbyNetworkConnector connector;
    void Start(){
        connector = GetComponent<LobbyNetworkConnector>();
        trigger.onClick.AddListener(CollectRoomOptions);
    }
    public void CollectRoomOptions(){
        RoomOptionFactory settings = new RoomOptionFactory();
        settings.setIsPublic(access.isPublic).setPlayer((int)maxplayer.Value).setDokkebi((int)dokplayer.Value);
        connector.setting = settings.build();
        Debug.Log(settings.ToString());
    }
}
