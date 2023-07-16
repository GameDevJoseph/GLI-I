using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
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

                if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6 | 1 << 8))
                {
                    Debug.Log(hitInfo.collider.name);

                }
            }
        }else if(UIManager.Instance.Ammo() <= 0)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            { 
                UIManager.Instance.Reload();
            }
        }
    }
}
