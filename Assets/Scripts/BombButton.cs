using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    public void SetTarget()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                var capsuleCollider = _enemies[i].GetComponent<BoxCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = true;
                }
            }
        }
    }

    public void CancleTarget()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                var capsuleCollider = _enemies[i].GetComponent<BoxCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = false;
                }
            }
        }
    }
}
