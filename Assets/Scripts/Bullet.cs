using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    public void BulletShoot(GameObject Target)
    {
        _target = Target;
    }

    private void Update()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * speed);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var character = _target.GetComponent<Character>();
        if(character != null)
        {
            character.Hp -= damage;
            if(character.Hp <= 0)
            {
                character.Death();
            }
            Destroy(gameObject);
        }
    }
}
