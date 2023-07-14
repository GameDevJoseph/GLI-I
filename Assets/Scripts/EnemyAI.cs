using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    enum AIStates
    {
        Run,
        Hide,
        Death
    };
    NavMeshAgent _agent;
    Transform _endPoint;
    Transform _selectedBarrier;
    bool _isHiding = false;
    bool _hasDied = false;
    float _hideTimer = 0;
    Animator _anim;
    

    [SerializeField] Vector3 _offset;
    [SerializeField] GameObject[] _barriers;
    [SerializeField] AIStates _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _barriers = GameObject.FindGameObjectsWithTag("Barrier");
        _agent = GetComponent<NavMeshAgent>();
        _endPoint = GameObject.Find("End Point").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        switch(_currentState)
        {
            case AIStates.Run: RunRoutine();  break;
            case AIStates.Hide:  HideRoutine(); break;
            case AIStates.Death: DeathRoutine(); break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndPoint"))
        {
            this.gameObject.SetActive(false);
        }
        if(other.CompareTag("Barrier"))
        {
            _isHiding = true;
            StartCoroutine(HideAtBarrier());
        }
    }

    void HideRoutine()
    {
        var nearestBarrier = float.MaxValue;

        if (_selectedBarrier == null)
        {
            foreach (GameObject barrier in _barriers)
            {
                float distance = Vector3.Distance(this.transform.position, barrier.transform.position);
                if (distance < nearestBarrier)
                {
                    nearestBarrier = distance;
                    _selectedBarrier = barrier.transform;
                }
            }
        }else
        {
            _agent.isStopped = false;
            _agent.SetDestination(_selectedBarrier.position + _offset);
        }
    }

    IEnumerator HideAtBarrier()
    {
        while(_isHiding)
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            _anim.SetBool("Hiding", true);
            yield return new WaitForSeconds(Random.Range(3f, 6f));
            _hideTimer = 0;
            _anim.SetBool("Hiding", false);
            _currentState = AIStates.Run;
            _isHiding = false;
            Debug.Log("Run Again");
        }
    }
    
    void RunRoutine()
    {
        _anim.SetFloat("Speed", 5f);
        _hideTimer += Time.deltaTime;
        _selectedBarrier = null;
        _agent.isStopped = false;
        _agent.SetDestination(_endPoint.position);

        var hideTimerRange = Random.Range(10f, 30f);

        if(_hideTimer > hideTimerRange)
        {
            _currentState = AIStates.Hide;
        }
    }

    void DeathRoutine()
    {
        if (_hasDied == false)
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            _anim.SetFloat("Speed", 0f);
            _anim.SetTrigger("Death");
            _hasDied = true;
        }
    }
}
