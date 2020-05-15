using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.UI;

public class CharacterMultiplayer : Character, IPunObservable
{
    public GameManager GameManager;
    //public List<GameObject> _players = new List<GameObject>();
    //public GameObject Interface;
    private bool _isAlive = true;
    [SerializeField] private Text _hp;

    public void Start()
    {
        _hp.text = Hp.ToString();
    }

    public void FixedUpdate()
    {
        if (_isAlive)
        {
            if (Hp <= 0)
                Death();
        }
    }

    public override void Death()
    {
        try
        {
            GameManager.EndGame(gameObject);
            _isAlive = false;
        } catch (NullReferenceException e)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(Hp);
        } else
        {
            Hp = (int)stream.ReceiveNext();
        }
    }

    public void UpdateHp()
    {
        _hp.text = Hp.ToString();
    }
}
