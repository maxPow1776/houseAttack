using System.Collections;
using UnityEngine;

public class FightWithEnemy : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _interface;

    public void StartFight()
    {
        var gun = _gun.GetComponent<Gun>();
        if(gun != null)
        {
            gun.Target = Target;
            gun.Shoot();
        }
        
        var shootButton = _interface.GetComponent<ShootButton>();
        if (shootButton != null)
        {
            shootButton.CancleTarget();
        }
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(2);
        var winPanel = _interface.GetComponent<WinPanel>();
        if (winPanel != null)
            winPanel.CheckEnemies();
    }
}
