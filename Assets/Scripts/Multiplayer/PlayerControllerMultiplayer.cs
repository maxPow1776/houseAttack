using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMultiplayer : MonoBehaviour
{
    [SerializeField] private LayerMask _canClick;
    private NavMeshAgent _navMeshAgent;
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_photonView.IsMine) return;
        if (Input.GetMouseButtonDown(1) && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100, _canClick))
            {
                _navMeshAgent.SetDestination(raycastHit.point);
            }
        }
    }
}
