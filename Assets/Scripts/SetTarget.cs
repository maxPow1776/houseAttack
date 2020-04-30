﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;

    private void OnMouseDown()
    {
        Debug.Log("press on mouse");
        for (int i = 0; i < _players.Length; i++)
        {
            var fightWithEnemy = _players[i].GetComponent<FightWithEnemy>();
            if (fightWithEnemy != null)
            {
                fightWithEnemy.Target = gameObject;
                fightWithEnemy.StartFight();
            }
        }
    }
}
