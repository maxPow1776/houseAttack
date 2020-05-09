﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _firstPosition;
    [SerializeField] private GameObject _secondPosition;
    public GameObject FollowCamera;

    void Start()
    {
        GameObject target = null;
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            target = PhotonNetwork.Instantiate(_playerPrefab.name, _secondPosition.transform.position, new Quaternion(0f, 180f, 0f, 0f));
        }
        else
            target = PhotonNetwork.Instantiate(_playerPrefab.name, _firstPosition.transform.position, Quaternion.identity);
        var followCamera = FollowCamera.GetComponent<FollowCamera>();
        if(followCamera != null )
        {
            followCamera.Target = target;
        }
    }

    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player enter " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left " + otherPlayer.NickName);
    }
}
