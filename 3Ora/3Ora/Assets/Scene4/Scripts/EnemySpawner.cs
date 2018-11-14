using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Vector2 _spawnTime;
    
    private Camera _cam;
    
    private void Start()
    {
        _cam = Camera.main;
        StartCoroutine(Spawn(2));
    }

    private IEnumerator Spawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        var randPos = Random.Range(0.05f, 0.95f);
        var newPos = _cam.ViewportToWorldPoint(new Vector2(randPos, 1));
        newPos.z = 0;
        Instantiate(_prefabToSpawn, newPos, Quaternion.identity);
        
        float nextWaitTime = Random.Range(_spawnTime.x, _spawnTime.y);
        StartCoroutine(Spawn(nextWaitTime));
    }
}
