using System;
using UnityEngine;

public class AnimatoinsController : MonoBehaviour
{
    //Мне не очень нравится, как происходит управление анимацией, но другого способа я не придумал. 
    //Может быть вы можете что-нибудь посоветовать?
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
        if (Math.Abs(_currentPosition.x -_previousPosition.x) < 0.001 && Math.Abs(_currentPosition.z - _previousPosition.z) < 0.001)
            _animator.SetBool(_isRunning, false);
        else
        {
            _animator.SetBool(_isRunning, true);
            _previousPosition = _currentPosition;
        }
    }
}
