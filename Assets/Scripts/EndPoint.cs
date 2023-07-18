using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _escapedClip;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _audioSource.PlayOneShot(_escapedClip);
        }
    }
}
