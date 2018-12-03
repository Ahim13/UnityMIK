using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public Transform[] Spawners;

    public GameObject[] Targets;

    public float StartSpeed = 2;
    public Vector2 TimeBetweenSpawn;

    private void Start()
    {
        StartCoroutine(SpawnObjects(2));
    }

    private IEnumerator SpawnObjects(float time)
    {
        yield return new WaitForSeconds(time);

        var target = Random.Range(0,Targets.Length);
        var pos = Random.Range(0,Spawners.Length);
        var spawnerTransform = Spawners[pos].transform;
        var go = Instantiate(Targets[target], spawnerTransform.position, Quaternion.identity);
        
        go.GetComponent<Rigidbody>().velocity = spawnerTransform.forward * StartSpeed;
        
        Destroy(go, 4);

        StartCoroutine(SpawnObjects(Random.Range(TimeBetweenSpawn.x, TimeBetweenSpawn.y)));
    }
}
