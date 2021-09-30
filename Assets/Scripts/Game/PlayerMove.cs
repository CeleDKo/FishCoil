using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _velocity;
    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _velocity = new Vector2(0, _speed);
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            _rigidBody2D.MovePosition(_rigidBody2D.position + _velocity * Time.fixedDeltaTime);
        }
    }
}