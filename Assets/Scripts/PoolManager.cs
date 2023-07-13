using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Pool Manager is null");

            return _instance;
        }
    }

    [SerializeField] GameObject _monsterContainer;
    [SerializeField] GameObject _monsterPrefab;
    [SerializeField]
    private List<GameObject> _monsterPool;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _monsterPool = GenerateMonsters(10);
    }
    List<GameObject> GenerateMonsters(int amountOfMonsters)
    {
        for (int i = 0; i < amountOfMonsters; i++)
        {
            GameObject monster = Instantiate(_monsterPrefab);
            monster.transform.parent = _monsterContainer.transform;
            monster.SetActive(false);
            _monsterPool.Add(monster);
        }
        return _monsterPool;
    }

    public GameObject RequestMonster()
    {
        
        foreach(GameObject monster in _monsterPool)
        {
            if (monster.activeInHierarchy == false)
            {
                monster.SetActive(true);
                return monster;
            }
        }
        return null;
    }


}
