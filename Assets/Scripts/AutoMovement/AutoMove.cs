using UnityEngine;
using UnityEngine.AI;

public class AutoMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void FollowMe(Vector3 finalPoint)
    {
        _navMeshAgent.SetDestination(finalPoint);
    }
}
