﻿using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] Points;

    private int _destPoint = 0;
    private NavMeshAgent _agent;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        _agent.SetDestination(Points[_destPoint].position);
        _destPoint = (_destPoint + 1) % Points.Length;
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.1f)
        {
            GotoNextPoint();
        }
    }
}