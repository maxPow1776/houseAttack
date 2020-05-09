using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOffset;

    public GameObject Target;

    private void Update()
    {
        if (Target != null)
        {
            transform.position = Target.transform.position + _positionOffset;
        }
    }
}
