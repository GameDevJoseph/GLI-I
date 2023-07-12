using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] Vector3 _targetDestination;
    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_targetDestination, transform.position);

        if(distance > 1.0f)
        {
            var direction = _targetDestination - transform.position;
            direction.Normalize();
            transform.Translate(direction * 2.0f * Time.deltaTime);
        }
    }

    public void UpdateDestination(Vector3 pos)
    {
        pos.y = 1.9f;
        _targetDestination = pos;
    }

    //public void challenegeOne()
    //{
    //    if (Mouse.current.leftButton.wasPressedThisFrame)
    //    {
    //        Vector3 mousePosition = Mouse.current.position.ReadValue();
    //Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);
    //RaycastHit hitInfo;

    //        if(Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6 | 1 << 7))
    //        {
    //            hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
    //        }
    //    }
    //}
}
