using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtonForMultiplayer : MonoBehaviour
{
    private PhotonView _photonView;
    public List<GameObject> _enemies = new List<GameObject>();
    PlayerControllerMultiplayer[] _players;

    public void SetTarget()
    {
        if (_players == null)
        {
            _players = FindObjectsOfType<PlayerControllerMultiplayer>();
            _enemies = ToList(_players);
        }
        for (int i = 0; i < _enemies.Count; i++)
        {
            _photonView = _enemies[i].GetPhotonView();
            if (_enemies[i] != null && !_photonView.IsMine)
            {
                var capsuleCollider = _enemies[i].GetComponent<CapsuleCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = true;
                }
            }
            if(_enemies[i] != null && _photonView.IsMine)
            {
                for (int j = 0; j < _enemies.Count; j++) {
                    var photonView = _enemies[j].GetPhotonView();
                    if (_enemies[j] != null && !photonView.IsMine)
                    {
                        var setTargetForMultiplayer = _enemies[j].GetComponent<SetTargetForMultiplayer>();
                        if (setTargetForMultiplayer != null)
                        {
                            setTargetForMultiplayer.Player = _enemies[i];
                        }
                    }
                }
            }
        }
    }

    public void CancleTarget()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _photonView = _enemies[i].GetPhotonView();
            if (_enemies[i] != null && !_photonView.IsMine)
            {
                var capsuleCollider = _enemies[i].GetComponent<CapsuleCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = false;
                }
            }
        }
    }

    private List<GameObject> ToList(PlayerControllerMultiplayer[] array)
    {
        List<GameObject> result = new List<GameObject>();
        for(int i = 0; i < array.Length; i++)
        {
            result.Add(array[i].gameObject);
        }
        return result;
    }
}