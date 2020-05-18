using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;

public class GunForMultiplayer : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _placeForBullet;
    public GameObject Target;
    public EnemyController Player;

    public void StartShoot()
    {
        StartCoroutine(Shoot());
    }

    public void OneShoot()
    {
        var bullet = PhotonNetwork.Instantiate(_bullet.name, Vector3.zero, Quaternion.identity);
        var bulletNavMeshAgent = bullet.GetComponent<NavMeshAgent>();
        if (bulletNavMeshAgent != null)
        {
            bulletNavMeshAgent.Warp(_placeForBullet.transform.position);
        }
        var currentBullet = bullet.GetComponent<Bullet>();
        if (currentBullet != null)
        {
            currentBullet.BulletShoot(Target);
        }
    }

    IEnumerator Shoot()
    {
        while (Target != null)
        {
            yield return new WaitForSeconds(2);
            OneShoot();
        }
        Player.StopFight();
    }
}
