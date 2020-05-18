using Photon.Pun;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform _target;

    public void Start()
    {
        var photonView = gameObject.GetComponent<PhotonView>();
        if(photonView.IsMine)
            _target = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        if(_target != null)
            transform.LookAt(_target);
    }
}
