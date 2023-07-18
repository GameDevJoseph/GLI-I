using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    int _enemiesKilled = 0;
    int _enemiesEscaped = 0;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is null");

            return _instance;
        }
    }

    [SerializeField] AudioSource _audioSource;
    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(_enemiesKilled == 10)
        {
            Debug.Log("Won");
        }

        if(_enemiesEscaped == (_enemiesKilled % 2))
        {
            Debug.Log("LOSE");
        }
    }

    public void NeededKillAmount()
    {
        _enemiesKilled++;
    }

    public void EnemiesEscaped()
    {
        _enemiesEscaped++;
    }
}
