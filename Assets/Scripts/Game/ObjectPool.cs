using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObjectPool : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private int _capacity;
    [SerializeField, Range(0, 20)] private float _minSpeedSpawn;
    [SerializeField, Range(0, 20)] private float _maxSpeedSpawn;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private bool _onlyBottomSpawn;
    private float _spawnCooldown;
    private List<GameObject> _pool = new List<GameObject>();
    private Vector3 _spawnObjectPosition;
    private void Start()
    {
        Initialize(_objectPrefab);
    }

    private void Update()
    {
        _spawnCooldown -= Time.deltaTime;

        if (_spawnCooldown <= 0)
        {
            if (TryGetObject(out GameObject _object))
            {
                _spawnCooldown = Random.Range(_minSpeedSpawn, _maxSpeedSpawn);
                if (_onlyBottomSpawn)
                    _spawnObjectPosition = new Vector3(13, -4.23f, 0);
                else
                    _spawnObjectPosition = new Vector3(13, Random.Range(-3f, 2.7f), 0);
                SetGameObject(_object, _spawnObjectPosition);
            }
        }
    }
    private void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    private void SetGameObject(GameObject _object, Vector3 spawnPoint)
    {
        _object.SetActive(true);
        _object.transform.position = spawnPoint;
        _object.transform.rotation = Quaternion.identity;
    }
    private bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => !p.activeSelf);

        return result != null;
    }
}