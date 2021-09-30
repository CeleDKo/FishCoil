using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private int _score;
    public int Score => _score;
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public Vector2 GetPlayerPosition()
    {
        return (Vector2)_player.transform.position;
    }
}
