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
    }

    
    //TODO: spawn enemys on random x positions after a time (think of Recursive methods) wait time aslo randomly selected in next iterations (dont forget to Start it somewhere on GameStart)
    private IEnumerator Spawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        var randPos = Random.Range(0.05f, 0.95f);

        
    }
}
