using UnityEngine;

public class AnimatoinsController : MonoBehaviour
{
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    private Animator _animator;
    private string _isRunning = "isRunning";

    void Start()
    {
        _previousPosition = gameObject.transform.position;
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        _currentPosition = gameObject.transform.position;
        if (Vector3.Distance(_previousPosition, _currentPosition) < 0.001)
            _animator.SetBool(_isRunning, false);
        else
        {
            _animator.SetBool(_isRunning, true);
            _previousPosition = _currentPosition;
        }
    }
}
