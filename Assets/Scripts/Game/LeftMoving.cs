using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LeftMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _velocity;
    private Rigidbody2D _rigidBody2D;
    private bool toPlayer;
    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _velocity = new Vector2(-_speed, 0);
    }
    private void FixedUpdate()
    {
        if (!toPlayer)
        {
            _rigidBody2D.MovePosition(_rigidBody2D.position + _velocity * Time.fixedDeltaTime);
            transform.rotation = Quaternion.identity;
        }
        else if (TryGetComponent<Worm>(out Worm worm))
        {
            Vector3 movePosition = transform.position;
            movePosition = Vector2.MoveTowards(transform.position, worm.GetPlayerPosition(), (_speed * 2) * Time.fixedDeltaTime);
            _rigidBody2D.MovePosition(movePosition);
        }
    }
    public void EnableMovingToPlayer()
    {
        toPlayer = true;
    }
    public void DisableMovingToPlayer()
    {
        toPlayer = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Destroyer"))
        {
            gameObject.SetActive(false);
        }
    }
}