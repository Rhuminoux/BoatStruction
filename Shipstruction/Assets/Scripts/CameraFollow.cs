using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private float _smoothSpeed = 0.125f;
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    private void FixedUpdate()
    {
        _desiredPosition = target.position + offset;
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);
        transform.position = target.position + offset;

        //transform.LookAt(target);
    }

}
