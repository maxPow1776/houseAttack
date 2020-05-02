using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] _players;

    private void OnMouseDown()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] != null)
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
}
