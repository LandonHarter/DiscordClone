using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public MicrophoneSetup micSetup;
    public TMP_InputField nicknameField;

    private void OnEnable()
    {
        nicknameField.text = PhotonNetwork.NickName;
        
        micSetup.UpdateMicrophone();
    }

    public void ChangeNickname()
    {
        PhotonNetwork.NickName = nicknameField.text;
        
        NetworkManager.ChangeNickname();
    }
}
