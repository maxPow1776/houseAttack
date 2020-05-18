using UnityEngine;
using UnityEngine.UI;

public class FightWithEnemyForMultiplayer : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private GameObject _gun;
    public GameObject Interface;
    public Button ShootButton;

    public void StartFight()
    {
        ShootButton.interactable = false;
        var gun = _gun.GetComponent<GunForMultiplayer>();
        if (gun != null)
        {
            gun.Target = Target;
            gun.OneShoot();
        }
        var shootButton = Interface.GetComponent<ShootButtonForMultiplayer>();
        if (shootButton != null)
        {
            shootButton.CancleTarget();
        }
    }
}
