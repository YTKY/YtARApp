using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonControllerScript : Photon.PunBehaviour {

	void Start () {
		
	}
	void Update () {
		
	}
    string _gameVersion = "test";

    public void Connect()   
    {
        if (!PhotonNetwork.connected) {  
            PhotonNetwork.ConnectUsingSettings(_gameVersion); 
            Debug.Log("Photonに接続しました。");
        }
    }
    public override void OnJoinedLobby()        
    {
        Debug.Log("ロビーに入りました。");
        PhotonNetwork.JoinRandomRoom(); 
    }
 
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("ルームの入室に失敗しました。");
        PhotonNetwork.CreateRoom("TestRoom");
    }
 
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました。");
        PhotonNetwork.LoadLevel("ARBattle");
    }
 
}
