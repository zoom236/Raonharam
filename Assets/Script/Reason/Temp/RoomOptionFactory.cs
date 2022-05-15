using System;
using Photon.Realtime;
/* <summury>
To Complete RoomOptions
*/
public class RoomOptionFactory
{
    private string name;
    private byte player;
    private bool ispublic;
    private int dok;
    private string quickcode;
    public RoomOptionFactory setRoomName(string name){
        this.name = name;
        return this;
    }
    public RoomOptionFactory setPlayer(int max){
        player = (byte)max;
        return this;
    }
    public RoomOptionFactory setIsPublic(bool ispublic){
        this.ispublic = ispublic;
        return this;
    }
    public RoomOptionFactory setDokkebi(int dok){
        this.dok = dok;
        return this;
    }
    public RoomOptions build(){
        RoomOptions op = new RoomOptions();
        if(player<5||player>12) return null;
        if(dok<1||dok>=player) return null;
        op.MaxPlayers = player;
        op.IsVisible = ispublic;
        op.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable(){{CustomRoom.keys[0],dok},{CustomRoom.keys[1],"AABBC1"}};
        op.CustomRoomPropertiesForLobby = CustomRoom.keys;
        return op;
    }
	public override string ToString()
	{
        string toprint = $"MaxPlayer : {player}\nAccess : {ispublic}\nDokkebi : {dok}\nJoinCode : aabbcc";
		return toprint;
	}
}
