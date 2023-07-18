using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _firingClip;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            UIManager.Instance.Reload();
        }
    }



    public void Shoot()
    {
        if (UIManager.Instance.Ammo() > 0)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                UIManager.Instance.RemoveAmmo();
                Vector3 mousePosition = Mouse.current.position.ReadValue();
                Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hitInfo;
                _audioSource.PlayOneShot(_firingClip);

                if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6 | 1 << 8))
                {
                    var damagable = hitInfo.collider.GetComponent<IDamagable>();

                    if(damagable != null)
                    {
                        damagable.Damage(10);
                        damagable.PlayDamageAudio();
                    }

                }
            }
        }else
        {
            return;
        }
    }
}
