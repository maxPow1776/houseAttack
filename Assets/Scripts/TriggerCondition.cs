using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCondition : MonoBehaviour
{
    [SerializeField] private GameObject _patrol;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() || other.GetComponent<AutoMove>())
        {
            var enemyController = _patrol.GetComponent<EnemyController>();
            if(enemyController != null)
            {
                enemyController.Rival = other.gameObject;
                enemyController.Fight();
            }
        }
    }
}
