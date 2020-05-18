using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _firstPosition;
    [SerializeField] private GameObject _secondPosition;
    [SerializeField] private GameObject _interface;
    [SerializeField] private Button  _shootButton;
    public GameObject FollowCamera;
    public List<GameObject> _players = new List<GameObject>();

    public void Start()
    {
        GameObject target = null;
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            target = PhotonNetwork.Instantiate(_playerPrefab.name, _secondPosition.transform.position, new Quaternion(0f, 180f, 0f, 0f));     
        }
        else
        {
            target = PhotonNetwork.Instantiate(_playerPrefab.name, _firstPosition.transform.position, Quaternion.identity);
        }
        var characterMultiplayer = target.GetComponent<CharacterMultiplayer>();
        if (characterMultiplayer != null)
            characterMultiplayer.GameManager = this;
        var fightWithEnemyForMultiplayer = target.GetComponent<FightWithEnemyForMultiplayer>();
        if(fightWithEnemyForMultiplayer != null)
        {
            fightWithEnemyForMultiplayer.Interface = _interface;
            fightWithEnemyForMultiplayer.ShootButton = _shootButton;
        }
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

    public void EndGame(GameObject loser)
    {
        var shootButton = _interface.GetComponent<ShootButtonForMultiplayer>();
        if(shootButton != null)
        {
            _players = shootButton._enemies;
        }
    }
}
