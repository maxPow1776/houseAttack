using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    private Vector3 offset = new Vector3(1.06f, 1.92f, -0.28f);

    public void Fight(GameObject target)
    {
        gameObject.GetComponent<Patrol>().CanPatrol = false;
        gameObject.transform.LookAt(target.transform.position);
        var position = gameObject.transform.position + offset;
        Debug.Log(position);
        _gun.transform.position = position;
        var rotation = gameObject.transform.rotation;
        _gun.transform.rotation = rotation;
    }
}
