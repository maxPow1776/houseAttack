using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMultiplayer : MonoBehaviour
{
    [SerializeField] private LayerMask _canClick;
    private NavMeshAgent _navMeshAgent;
    //[SerializeField] private GameObject[] _team;
    //private Vector3[] _distance = { new Vector3(-3, 0, 3), new Vector3(3, 0, 3), new Vector3(0, 0, 6) };
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_photonView.IsMine) return;
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100, _canClick))
            {
                _navMeshAgent.SetDestination(raycastHit.point);
                //for (int i = 0; i < _team.Length; i++)
                //{
                //    if (_team[i] != null)
                //    {
                //        var autoMove = _team[i].GetComponent<AutoMove>();
                //        if (autoMove != null)
                //            autoMove.FollowMe(new Vector3(raycastHit.point.x + _distance[i].x, raycastHit.point.y, raycastHit.point.z + _distance[i].z));
                //    }
                //}
            }
        }
    }
}
