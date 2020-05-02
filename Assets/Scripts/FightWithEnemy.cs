using System.Collections;
using System.Collections.Generic;
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
    }
}
