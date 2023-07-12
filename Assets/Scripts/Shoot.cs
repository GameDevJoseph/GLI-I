using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject _bulletHolePrefab;
    
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f,0)); ;
            RaycastHit hitInfor;

            if(Physics.Raycast(rayOrigin, out hitInfor))
            {
                Instantiate(_bulletHolePrefab, new Vector3(hitInfor.point.x + 0.01f, hitInfor.point.y, hitInfor.point.z), Quaternion.LookRotation(hitInfor.normal));
            }
        }
    }
}
