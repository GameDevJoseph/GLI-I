using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;

    [SerializeField] GameObject _monsterPrefab;
    [SerializeField] Transform _spawnPosition;
    int maxAmountToSpawn = 10;
    int currentAmountSpawned = 0;

    public static SpawnManager Instance
    {
        get 
        {
            if ((_instance == null))
                Debug.LogError("SpawnManager is null");
            
            return _instance; 
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartSpawning();
    }

    public void SpawnAI()
    {
        GameObject monster = PoolManager.Instance.RequestMonster();
        monster.transform.position = _spawnPosition.position;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (currentAmountSpawned <= maxAmountToSpawn)
        {
            SpawnAI();
            currentAmountSpawned++;
            yield return new WaitForSeconds(20f);
        }
    }
}


