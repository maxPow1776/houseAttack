using UnityEngine;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    public void SetTarget()
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                var capsuleCollider = _enemies[i].GetComponent<CapsuleCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = true;
                }
            }
        }
    }

    public void CancleTarget()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                var capsuleCollider = _enemies[i].GetComponent<CapsuleCollider>();
                if (capsuleCollider != null)
                {
                    capsuleCollider.enabled = false;
                }
            }
        }
    }
}
