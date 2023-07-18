using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IDamagable
{
    [SerializeField] int _hp = 100;
    bool _isActive = true;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _damageClip;
    


    public bool isActive { get { return _isActive; } }


    public void Damage(int amount)
    {
        _hp -= amount;
    }

    void Update()
    {
        if(_hp <= 0)
        {
            _isActive = false;
        }
    }

    IEnumerator BarrierRecharge()
    {
        while (_isActive == false)
        {
            yield return null;
        }
    }

    public void PlayDamageAudio()
    {
        _audioSource.PlayOneShot(_damageClip);
    }
}
