using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager_test : MonoBehaviourPunCallbacks
{
    public static NetworkManager_test instance;
    public InputField NickNameInput;
    public GameObject DisconnectPanel;
    public GameObject InventoryUI;
    public GameObject ItemButton;
    public Transform SpawnPos;
    
    public bool doke;

    private void Awake()
    {
        instance = this;
        Screen.SetResolution(1920, 1080, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Children()
    {
        Connect();
    }

    public void Dokebi()
    {
        doke = true;
        Connect();
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room test for inven", new RoomOptions { MaxPlayers = 8 }, null);
    }

    public override void OnJoinedRoom()
    {
        DisconnectPanel.SetActive(false);
        InventoryUI.SetActive(true);
        ItemButton.SetActive(true);
        Spawn();
    }

    public void Spawn()
    {
        if(!doke)
        {
            PhotonNetwork.Instantiate("Kid", SpawnPos.position, Quaternion.identity);

        }
        else
        {
            PhotonNetwork.Instantiate("Dokkebi", SpawnPos.position, Quaternion.identity);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        DisconnectPanel.SetActive(true);
    }
}
