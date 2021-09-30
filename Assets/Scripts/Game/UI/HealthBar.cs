using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerCollisionSystem _playerCollisionSystem;
    private void Start()
    {
        ChangeHealthBar(_playerCollisionSystem.Health);
    }
    private void OnEnable()
    {
        _playerCollisionSystem.ApplyDamage += ChangeHealthBar;
    }
    private void OnDisable()
    {
        _playerCollisionSystem.ApplyDamage -= ChangeHealthBar;
    }
    private void ChangeHealthBar(int _health)
    {
        _healthSlider.value = (float)_health;
    }
}