using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class CharacterMultiplayer : Character
{
    public GameManager GameManager;
    //public List<GameObject> _players = new List<GameObject>();
    //public GameObject Interface;
    private bool _isAlive = true;

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
}
