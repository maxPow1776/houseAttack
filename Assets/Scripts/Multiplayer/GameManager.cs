using Photon.Pun;
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

    void Start()
    {
        Vector3 currentPosition = Vector3.zero;
        var firstPosition = _firstPosition.GetComponent<Position>();
        if(firstPosition != null)
        {
            if(firstPosition.IsEmpty)
            {
                currentPosition = _firstPosition.transform.position;
                firstPosition.IsEmpty = false;
            } else
            {
                var secondPosition = _secondPosition.GetComponent<Position>();
                if(secondPosition != null)
                {
                    currentPosition = _secondPosition.transform.position;
                    secondPosition.IsEmpty = false;
                }
            }
        }
        PhotonNetwork.Instantiate(_playerPrefab.name, currentPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
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
