using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeDistance : MonoBehaviour
{
    [SerializeField] private PlayerCollisionSystem _playerCollisionSystem;
    [SerializeField] private GameController _gameController;
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private float speed;
    private int _distance;
    private bool playerIsAlive;
    private void Start()
    {
        _distanceText.text = _distance + " м";
        playerIsAlive = true;
        StartCoroutine(ChangingDistance());
    }
    public IEnumerator ChangingDistance()
    {
        while (playerIsAlive)
        {
            _distance += 1;
            _distanceText.text = _distance + " м";
            _gameController.AddDistance(1);
            yield return new WaitForSeconds(speed);
        }
    }
    private void OnEnable()
    {
        _playerCollisionSystem.PlayerDeath += DisableChanginDistance;
    }
    private void OnDisable()
    {
        _playerCollisionSystem.PlayerDeath -= DisableChanginDistance;
    }
    public void DisableChanginDistance()
    {
        playerIsAlive = false;
    }
}
