using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWithEnemyForMultiplayer : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private GameObject _gun;
    public GameObject Interface;

    public void StartFight()
    {
        var gun = _gun.GetComponent<Gun>();
        if (gun != null)
        {
            gun.Target = Target;
            gun.Shoot();
        }

        var shootButton = Interface.GetComponent<ShootButtonForMultiplayer>();
        if (shootButton != null)
        {
            shootButton.CancleTarget();
        }
        //StartCoroutine(Check());
    }

    //IEnumerator Check()
    //{
    //    yield return new WaitForSeconds(2);
    //    var winPanel = _interface.GetComponent<WinPanel>();
    //    if (winPanel != null)
    //        winPanel.CheckEnemies();
    //}
}
