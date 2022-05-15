using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyNetworkConnector : MonoBehaviourPunCallbacks
{
#region Private Serializable Fields
    [SerializeField]
    Text RoomNames;
#endregion
#region Private Fields
    string gameVersion = "1";
    bool isConnecting;
    Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
#endregion
#region Public Fields
    public RoomOptions setting;
#endregion
#region MonoBehaviour CallBacks
    void Awake(){
        PhotonNetwork.AutomaticallySyncScene = true;
    }
#endregion
#region MonoBehaviourPunCallbacks Callbacks
    public override void OnConnectedToMaster(){
        if(isConnecting){
            Debug.Log("OnConnectedToMaster() was called by PUN");
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnJoinedLobby(){
        Debug.Log("OnJoinedLobby() was called by PUN");
        cachedRoomList.Clear();
        RoomNames.text = "룸 이름";
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        Debug.Log("OnRoomListUpdate() was called by PUN");
        UpdateCachedRoomList(roomList);
    }
#endregion
#region Private Methods
    void UpdateCachedRoomList(List<RoomInfo> roomList){
        for(int i= 0;i<roomList.Count; i++){
            RoomInfo info = roomList[i];
            if(info.RemovedFromList){
                cachedRoomList.Remove(info.Name);
            }
            else{
                cachedRoomList[info.Name] = info;
                RoomNames.text += "\n"+ info.Name;
            }
        }
    }
#endregion
#region Public Methods
    public void Connect(){
        isConnecting = true;
        if(PhotonNetwork.IsConnected){
            PhotonNetwork.JoinLobby();
            Debug.Log("Already Connected");
        }
        else{
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Try Connecting");
        }
    }
#endregion
}
