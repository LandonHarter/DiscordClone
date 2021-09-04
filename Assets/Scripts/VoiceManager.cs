using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviourPunCallbacks
{

    public Button vcButton;
    public Button createVCButton;

    public void JoinOrLeaveVC()
    {
        if (!PhotonNetwork.InRoom)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public void CreateVC()
    {
        string name = "Room" + Random.Range(0, 100000000);
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        
        PhotonNetwork.CreateRoom(name, roomOptions);

        createVCButton.interactable = false;
    }

    public override void OnJoinRandomFailed(short exitcode, string message)
    {
        NetworkManager.Instance.messages.text += "Discord: There are no voice chats currently available, try creating your own. \n";
    }

    public override void OnJoinedRoom()
    {
        vcButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Leave VC";
    }

    public override void OnLeftRoom()
    {
        vcButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Join VC";
        createVCButton.interactable = true;
    }

}
