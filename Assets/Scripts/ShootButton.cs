using UnityEngine;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    public void Start()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            var setTarget = _enemies[i].GetComponent<SetTarget>();
            if (setTarget != null)
            {
                Debug.Log(setTarget.enabled);
                setTarget.enabled = false;
                Debug.Log(setTarget.enabled);
            }
        }
    }

    public void SetTarget()
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                var setTarget = _enemies[i].GetComponent<SetTarget>();
                if (setTarget != null)
                {
                    Debug.Log(setTarget.enabled);
                    setTarget.enabled = true;
                    Debug.Log(setTarget.enabled);
                }
            }
        }
    }
}
