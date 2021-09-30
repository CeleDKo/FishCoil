using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBar : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private Slider _bonusBarSlider;
    [SerializeField] private PlayerCollisionSystem _playerCollisionSystem;
    [SerializeField] private float _speed;
    private void OnEnable()
    {
        _playerCollisionSystem.GettingBonus += EnableBonusBar;
    }
    private void OnDisable()
    {
        _playerCollisionSystem.GettingBonus -= EnableBonusBar;
    }
    private void EnableBonusBar(float _duration, GameObject bonus)
    {
        _gameController.AddBonus(1);
        _bonusBarSlider.value = 1f;
        StartCoroutine(EnableChangingBonusBar(_duration, bonus));
    }
    public IEnumerator EnableChangingBonusBar(float _duration, GameObject bonus)
    {
        float t = 0;
        while (t < _duration)
        {
            _bonusBarSlider.value = Mathf.Lerp(1f, 0f, t / _duration);
            t += Time.deltaTime;
            yield return null;
        }
        _bonusBarSlider.value = 0f;
        if (bonus.TryGetComponent<Shield>(out Shield shield))
            shield.FromPlayer(_playerCollisionSystem);
        else if (bonus.TryGetComponent<Magnet>(out Magnet magnet))
            magnet.DisablePull();
    }
}