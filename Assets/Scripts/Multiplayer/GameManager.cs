using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _firstPosition;
    [SerializeField] private GameObject _secondPosition;
    private PhotonView _photonView;
    private bool _isFirst = true;
    private int count = 0;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_isFirst)
        {
            PhotonNetwork.Instantiate(_playerPrefab.name, _firstPosition.transform.position, Quaternion.identity);
            Debug.Log("Instantiate " + count);
            count++;
            Debug.Log("Instantiate " + count);
            if (_photonView.IsMine)
                _isFirst = false;
        }
        else
            PhotonNetwork.Instantiate(_playerPrefab.name, _secondPosition.transform.position, Quaternion.identity);
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
        Debug.Log("Player enter " + newPlayer.NickName + count);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left " + otherPlayer.NickName);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(count);
        } else
        {
            count = (int)stream.ReceiveNext();
        }
    }
}
