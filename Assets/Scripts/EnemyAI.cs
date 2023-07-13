using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent _agent;

    Transform _endPoint;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _endPoint = GameObject.Find("End Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_endPoint.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndPoint"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
