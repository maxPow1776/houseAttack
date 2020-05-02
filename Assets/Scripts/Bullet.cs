using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private int damage;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Debug.Log("Bullet was instantiate");
    }

    public void BulletShoot(GameObject Target)
    {
        _target = Target;
    }

    private void Update()
    {
        if (_target != null)
            _navMeshAgent.SetDestination(_target.transform.position);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_target != null)
        {
            var character = _target.GetComponent<Character>();
            if (character != null)
            {
                character.Hp -= damage;
                if (character.Hp <= 0)
                {
                    character.Death();
                }
                Destroy(gameObject);
            }
        }
    }
}
