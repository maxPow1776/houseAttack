﻿using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    public GameObject Target;
    public int damage;
    public NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Target != null)
            _navMeshAgent.SetDestination(Target.transform.position);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Target != null)
        {
            var character = Target.GetComponent<Character>();
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
