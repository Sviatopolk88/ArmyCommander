using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
    private NavMeshAgent _agent;
    private AnimatorController _animator;
    private Transform _target;
    private Vector3 _homePosition;
    private Vector3 _defaultRotate;
    private bool _isAttacked = false;
    private bool _isReturningHome = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<AnimatorController>();
        _defaultRotate = transform.forward;

        if (gameObject.layer == 6)
        {
            _isReturningHome = true;
            _homePosition = transform.position;
        }
    }
    private void Update()
    {
        if (_isAttacked)
        {
            _agent.SetDestination(_target.position);
            var distanceAttack = Vector3.Distance(_target.position, transform.position);
            if (distanceAttack - _agent.stoppingDistance <= 0)
            {
                _animator.ShootAnimation();
            }
            if (_isReturningHome)
            {
                var attackRange = Mathf.Abs(Vector3.Distance(transform.position, _homePosition));
                if (attackRange > 5)
                {
                    BackToHome();
                }
            }
        }
        
        else if (_agent.remainingDistance < 0.2f)
        {
            _animator.IdleAnimation();
            transform.LookAt(_defaultRotate + transform.position);
        } 
        
    }
    public void MoveToAttack(GameObject target)
    {
        _target = target.transform;
        _agent.stoppingDistance = 7.0f;
        _isAttacked = true;
    }
    public void BackToHome()
    {
        _isAttacked = false;
        _agent.SetDestination(_homePosition);
        _agent.stoppingDistance = 0;
    }
    public void MoveToPoint(Vector3 targetPoint)
    {
        if (targetPoint != null)
        {
            _isAttacked = false;
            Debug.Log(targetPoint);
            _agent.SetDestination(targetPoint);
            _agent.stoppingDistance = 0;
        }
        
    }
    public void StopUnit()
    {
        _isAttacked = false;
        _agent.isStopped = true;
    }
}
