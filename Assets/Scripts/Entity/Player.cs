using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rotationSensivity = 1;
    [SerializeField] private Transform _verticalRotationTransform;
    [SerializeField] private Transform _horizontalRotationTransform;

    private Vector2 MousePosition;

    public override void Attack(Entity target)
    {

    }

    public override void Move(Vector3 target)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += _speed * _horizontalRotationTransform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= _speed * _horizontalRotationTransform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _speed * _horizontalRotationTransform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= _speed * _horizontalRotationTransform.right;
        }

        float horizontalRotation = MousePosition.x - Input.mousePosition.x;
        float verticalRotation = MousePosition.y - Input.mousePosition.y;

        _horizontalRotationTransform.localEulerAngles += Vector3.up * horizontalRotation * _rotationSensivity;

        _verticalRotationTransform.localEulerAngles += Vector3.right * verticalRotation * _rotationSensivity;

        MousePosition = Input.mousePosition;
    }

    void Update()
    {
        Move(Vector3.zero);
    }
}
