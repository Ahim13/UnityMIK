using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;

    private void OnDisable()
    {
        if (this.enabled == false)
            Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
    }
}