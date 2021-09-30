using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _score;
    public int Score => _score;
    public int ScoreTaked;
    [SerializeField] private int _distanceTraveled;
    public int Distance => _distanceTraveled;
    [SerializeField] private int _bonusTaked;
    public int BonusTaked => _bonusTaked;
    private void Start()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
    }
    public int AddDistance(int _needeAddDistance)
    {
        return _distanceTraveled += _needeAddDistance;
    }
    public int AddScore(int _needeAddScore)
    {
        ScoreTaked += _needeAddScore;
        return _score += _needeAddScore;
    }
    public int AddBonus(int _neededAddBonus)
    {
        return _bonusTaked += _neededAddBonus;
    }
}