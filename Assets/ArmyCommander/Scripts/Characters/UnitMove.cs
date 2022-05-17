using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private AnimatorController _animator;
    private Transform _target;
    private float _stopDistance;
    private bool _isTarget = false;
    private Vector3 _defaultRotate;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<AnimatorController>();
        _defaultRotate = transform.forward;
    }

    private void Update()
    {
        if(_agent.velocity == Vector3.zero)
        {
            _animator.IdleAnimation();
        }

        if (_isTarget && _target != null)
        {
            _agent.SetDestination(_target.position);
            _agent.stoppingDistance = _stopDistance;
            _animator.RunAnimation();
        }

        if (!_agent.pathPending && _agent.remainingDistance < 0.3f)
        {
            _animator.IdleAnimation();
            transform.LookAt(_defaultRotate + transform.position);
        }
    }

    public void MoveTo(GameObject target, float stopDistance)
    {
        if (target != null)
        {
            _target = target.transform;
            _stopDistance = stopDistance;
            _isTarget = true;
        }
    }

    public void BackToHome(Vector3 target, float stopDistance)
    {
        _isTarget = false;
        _agent.SetDestination(target);
        _agent.stoppingDistance = stopDistance;
    }

    public void StopUnit()
    {
        _animator.IdleAnimation();

        _isTarget = false;
        _agent.isStopped = true;
    }
}
