using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSprite : MonoBehaviour
{
    int _dirIndex;
    float _angle;

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 fwd = transform.forward;
        fwd.y = 0;

        Vector3 dir = Camera.main.transform.position - transform.position;
        dir.y = 0;
        _angle = Vector3.Angle(dir, fwd) * Mathf.Sign(transform.InverseTransformPoint(Camera.main.transform.position).x);

        _angle %= 360;
        if (_angle < 0)
            _angle += 360;

        // Convert _angle to direction index
        if (_angle >= 45 && _angle < 135)
            _dirIndex = 2; // 90
        else if (_angle >= 135 && _angle < 225)
            _dirIndex = 1; // 0
        else if (_angle >= 225 && _angle < 315)
            _dirIndex = 4; // -90
        else
            _dirIndex = 3; // 180;

        print(_dirIndex);

        _animator.SetInteger("Direction", _dirIndex);
    }
}
