using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;


    float _timer = 300f;
    int _enemyCount = 0;
    int _score = 0;
    int _ammoCount = 10;
    

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is Null");

            return _instance;
        }
    }

    [SerializeField] TMP_Text _timerText;
    [SerializeField] TMP_Text _enemyCountText;
    [SerializeField] TMP_Text _scoreAmountText;
    [SerializeField] TMP_Text _ammoCountText;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _enemyCountText.text = _enemyCount.ToString();
        _ammoCountText.text = _ammoCount.ToString();
    }

    private void Update()
    {
        TimerSystem();

        if (_ammoCount <= 0)
        {
            _ammoCount = 0;
        }
    }

    void TimerSystem()
    {
        _timer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(_timer / 60);
        float seconds = Mathf.FloorToInt(_timer % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddToEnemyCount()
    {
        _enemyCount += 1;
        _enemyCountText.text = _enemyCount.ToString();
    }

    public void RemoveFromEnemyCount()
    {
        _enemyCount -= 1;
        _enemyCountText.text = _enemyCount.ToString();
    }

    public void AddToScore(int amount)
    {
        _score += amount;
        _scoreAmountText.text = _score.ToString();
    }

    public void RemoveAmmo()
    {
        _ammoCount -= 1;
        _ammoCountText.text = _ammoCount.ToString();
    }

    public int Ammo()
    {
        return _ammoCount;
    }

    

    public void Reload()
    {
        _ammoCount = 10;
        _ammoCountText.text = _ammoCount.ToString();
    }


    
}
