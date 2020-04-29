using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _placeForGun;

    public GameObject Rival;

    public void Fight()
    {
        var patrol = gameObject.GetComponent<Patrol>();
        if(patrol != null)
        {
            patrol.CanPatrol = false;
        }
        gameObject.transform.LookAt(Rival.transform.position);
        _gun.transform.position = _placeForGun.transform.position;
        var rotation = gameObject.transform.rotation;
        _gun.transform.rotation = rotation;
        var gun = _gun.GetComponent<Gun>();
        if(gun != null)
        {
            gun.Target = Rival;
            gun.StartShoot();
        }
    }
}
