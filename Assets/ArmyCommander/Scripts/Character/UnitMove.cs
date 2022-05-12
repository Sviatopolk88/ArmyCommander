using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;
    private float _stopDistance;
    private bool _isTarget = false;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isTarget)
        {
            _agent.SetDestination(_target.position);
            _agent.stoppingDistance = _stopDistance;
        }
    }

    public void MoveTo(GameObject target, float stopDistance)
    {
        _target = target.transform;
        _stopDistance = stopDistance;
        _isTarget = true;
    }

    public void BackToHome(Vector3 target, float stopDistance)
    {
        _isTarget = false;
        _agent.SetDestination(target);
        _agent.stoppingDistance = stopDistance;
    }

    public void StopUnit()
    {
        _isTarget = false;
        _agent.isStopped = true;
    }
}
