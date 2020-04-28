using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCondition : MonoBehaviour
{
    [SerializeField] private GameObject _patrol;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter on trigger");
        if(other.GetComponent<PlayerController>() || other.GetComponent<AutoMove>())
        {
            _patrol.GetComponent<EnemyController>().Fight(other.gameObject);
        }
    }
}
