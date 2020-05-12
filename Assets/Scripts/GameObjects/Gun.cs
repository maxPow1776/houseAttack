using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _placeForBullet;
    public GameObject Target;
    public EnemyController Player;

    public void StartShoot()
    {
        //InvokeRepeating("Shoot", 0, 2);
        StartCoroutine(Shoot());
    }

    public void OneShoot()
    {
        var bullet = Instantiate(_bullet, _placeForBullet.transform.position, Quaternion.identity);
        var currentBullet = bullet.GetComponent<Bullet>();
        if(currentBullet != null)
        {
            currentBullet.BulletShoot(Target);
        }
    }

    //public void StopShoot()
    //{
    //    CancelInvoke("Shoot");
    //}

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
