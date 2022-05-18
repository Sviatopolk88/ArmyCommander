using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
    private NavMeshAgent _agent;
    private AnimatorController _animator;
    private Transform _target;
    private Vector3 _homePosition;
    private Vector3 _defaultRotate;

    private bool _isAttacking = false;
    private bool _isMoveToAttack = false;
    private bool _isMoveToPoint = false;
    private bool _isReturningHome = false;
    private bool _isBackToHome = false;

    private float _stopDistanceAttack = 6.0f;

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
        if (_isMoveToAttack)
        {
            if (_target != null)
            {
                _agent.SetDestination(_target.position);
                _agent.stoppingDistance = _stopDistanceAttack;
                _animator.RunAnimation();
                float D = (float)Mathf.Abs(Vector3.Distance(_target.position, transform.position));
                var distanceAttack = D - _stopDistanceAttack;
                if (distanceAttack <= 0)
                {
                    _isMoveToAttack = false;
                    _animator.ShootAnimation();
                    _isAttacking = true;
                }
            }
        }

        if (_isAttacking)
        {
            if (_target != null)
            {
                var distanceToTarget = Mathf.Abs(Vector3.Distance(_target.position, transform.position));
                if (distanceToTarget > _stopDistanceAttack)
                {
                    _isAttacking = false;
                    _isMoveToAttack = true;
                    _animator.RunAnimation();
                }
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
        
        if (_isMoveToPoint)
        {
            _agent.SetDestination(_target.position);
            _animator.RunAnimation();
            _isMoveToPoint = false;
        }
        
        if (_agent.remainingDistance < 0.1f)
        {
            _animator.IdleAnimation();
            transform.LookAt(_defaultRotate + transform.position);
        } 
        
        if (_isBackToHome)
        {
            _agent.SetDestination(_homePosition);
            _agent.stoppingDistance = 0;
            _isBackToHome = false;
        }

    }

    public void MoveToAttack(Transform target)
    {
        _target = target;
        
        _isMoveToAttack = true;
    }
    public void BackToHome()
    {
        _isAttacking = false;
        _isMoveToAttack = false;
        _isBackToHome = true;
        _animator.RunAnimation();
    }
    public void MoveToPoint(Transform targetPoint)
    {
        _isAttacking = false;
        _isMoveToPoint = true;
        _target = targetPoint;
        
    }
    public void StopUnit()
    {
        _isAttacking = false;
        _agent.isStopped = true;
        _animator.IdleAnimation();
    }
}
