using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionSystem : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] PlaySounds _playSounds;
    private bool _invulnerable;
    public int Health => _health;
    public UnityAction<int> ApplyDamage;
    public UnityAction<int> GettingPoints;
    public UnityAction PlayerDeath;
    public UnityAction<float, GameObject> GettingBonus;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            TakeDamage(enemy.Damage);
        }
        else if (collider.TryGetComponent<Worm>(out Worm worm))
        {
            _playSounds.PlaySound(PlaySounds.SoundType.TakeScore);
            GettingPoints?.Invoke(worm.Score);
            worm.gameObject.SetActive(false);
        }
        else if (collider.TryGetComponent<Shield>(out Shield shield))
        {
            shield.OnPlayer(this);
            _playSounds.PlaySound(PlaySounds.SoundType.TakeBonus);
            GettingBonus?.Invoke(shield.Duration, shield.gameObject);
        }
        else if (collider.TryGetComponent<Magnet>(out Magnet magnet))
        {
            magnet.EnablePull();
            _playSounds.PlaySound(PlaySounds.SoundType.TakeBonus);
            GettingBonus?.Invoke(magnet.Duration, magnet.gameObject);
        }
    }
    private void TakeDamage(int _damage)
    {
        if (_invulnerable)
            return;

        if (_damage < 0)
            throw new Exception("Урон меньше 0");

        Debug.Log("Получено урона " + _damage);
        _animator.SetTrigger("Blink");

        _health -= _damage;
        _playSounds.PlaySound(PlaySounds.SoundType.Damage);

        if (_health <= 0)
            Death();

        ApplyDamage?.Invoke(_health);
    }
    private void Death()
    {
        PlayerDeath?.Invoke();
    }

    public void EnableInvulnerability()
    {
        _invulnerable = true;
    }
    public void DisableInvulnerability()
    {
        _invulnerable = false;
    }
}