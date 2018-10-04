using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Collider2D _spawnArea;
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float _scoreUntilSpawn = 15;

    private void Start()
    {
        StartCoroutine(SpawnObjectCoroutine());
        //InvokeRepeating("SpawnObject", 0, _timeBetweenSpawns); //Alternative way --> bad
    }

    private IEnumerator SpawnObjectCoroutine()
    {
        while (PointsManager.Instance.Score < _scoreUntilSpawn)
        {
            SpawnObject();
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }

    private void SpawnObject()
    {
        var randPos = new Vector2(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x), Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y));
        Instantiate(_prefabToSpawn, randPos, Quaternion.identity);
    }
}