using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform _target;

    public void Start()
    {
        if(gameObject.GetComponent<PhotonView>().IsMine)
            _target = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        if(_target != null)
            transform.LookAt(_target);
    }
}
