using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class DisableItems : MonoBehaviourPunCallbacks
{

    public GameObject[] objects;

    void Update()
    {
        if (!photonView.IsMine)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }
    }

}
