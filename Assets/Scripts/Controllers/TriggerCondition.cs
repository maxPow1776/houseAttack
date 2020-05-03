using UnityEngine;

public class TriggerCondition : MonoBehaviour
{
    [SerializeField] private GameObject _patrol;

    private void OnTriggerEnter(Collider other)
    {
        if (_patrol != null)
        {
            if (other.GetComponent<PlayerController>() || other.GetComponent<AutoMove>())
            {
                var enemyController = _patrol.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    if (!enemyController.IsBusy)
                    {
                        enemyController.Rival = other.gameObject;
                        enemyController.Fight();
                        enemyController.IsBusy = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_patrol != null)
        {
            if (other.GetComponent<PlayerController>() || other.GetComponent<AutoMove>())
            {
                var enemyController = _patrol.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    if (enemyController.IsBusy)
                    {
                        enemyController.Rival = null;
                        enemyController.StopFight();
                        enemyController.IsBusy = false;
                    }
                }
            }
        }
    }
}
