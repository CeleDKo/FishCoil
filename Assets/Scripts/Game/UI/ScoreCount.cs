using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCountText;
    [SerializeField] private PlayerCollisionSystem _playerCollisionSystem;
    [SerializeField] private GameController _gameController;
    private int _scoreCount;
    private void Start()
    {
        _scoreCount = PlayerPrefs.GetInt("Score", 0);
        _scoreCountText.text = _scoreCount.ToString();
    }
    private void OnEnable()
    {
        _playerCollisionSystem.GettingPoints += AddingScore;
    }
    private void OnDisable()
    {
        _playerCollisionSystem.GettingPoints -= AddingScore;
    }

    private void AddingScore(int _score)
    {
        _scoreCount += _score;
        _scoreCountText.text = _scoreCount.ToString();
        _gameController.AddScore(_score);
    }
}