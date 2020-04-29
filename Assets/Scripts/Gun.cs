using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _placeForBullet;
    public GameObject Target;

    public void StartShoot()
    {
        InvokeRepeating("Shoot", 0, 2);
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _placeForBullet.transform.position, Quaternion.identity);
        var currentBullet = bullet.GetComponent<Bullet>();
        if(currentBullet != null)
        {
            currentBullet.BulletShoot(Target);
        }
    }
}
