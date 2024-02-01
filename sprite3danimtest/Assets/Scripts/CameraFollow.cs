using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    Vector3 _offset;

    private void Start()
    {
        _offset = transform.position;
    }

    void Update()
    {
        transform.position = Target.position + _offset;
    }
}
