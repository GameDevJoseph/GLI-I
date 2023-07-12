using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{
    enum AIState
    {
        Walking,
        Attack,
        Jumping,
        Death
    }
    [SerializeField] List<Transform> _waypoints;
    NavMeshAgent _agent;
    int _currentPoint = 0;
    bool _inReverse = false;
    [SerializeField] AIState _currentState;
    bool _isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if(_agent != null)
        {
            _agent.destination = _waypoints[_currentPoint].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case AIState.Walking: CalculateAIMovement(); break;
            case AIState.Attack: if (_isAttacking == false) { StartCoroutine(AttackRoutine()); _isAttacking = true; } break;
            case AIState.Jumping: break;
            case AIState.Death: break;
        }

        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            _agent.isStopped = true;
            _currentState = AIState.Jumping;
        }
    }

    private void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 1f)
        {
            if (_inReverse == true)
                Reverse();
            else
                Forward();

            _agent.SetDestination(_waypoints[_currentPoint].position);

            _currentState = AIState.Attack;
        }
    }

    private void Forward()
    {
        if (_currentPoint == _waypoints.Count - 1)
        {
            _inReverse = true;
            _currentPoint--;
        }
        else
            _currentPoint++;
    }

    private void Reverse()
    {
        if (_currentPoint == 0)
        {
            _inReverse = false;
            _currentPoint++;
        }
        else
            _currentPoint--;
    }

    IEnumerator AttackRoutine()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        _agent.isStopped = false;
        _currentState = AIState.Walking;
        _isAttacking = false;
    }
}
