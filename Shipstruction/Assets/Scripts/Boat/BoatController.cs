using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Joystick joystick;

    public float _smoothSpeed = 010f;
    private Vector3 _smoothedRotation;
    private Vector3 _desiredRotation;
    private Rigidbody _rb;
    private float _speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            _desiredRotation = new Vector3(0, (Mathf.Atan2(joystick.Vertical, -joystick.Horizontal) * 180 / Mathf.PI) - 90, 0);
            //_smoothedRotation = Vector3.Lerp(transform.eulerAngles, _desiredRotation, Time.deltaTime * _smoothSpeed);
            transform.eulerAngles = _desiredRotation;
        }
        _rb.MovePosition(_rb.position + (transform.rotation * Vector3.forward) * _speed * Time.fixedDeltaTime);
    }
}
