using System.Collections;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public float TimeRecharge = 0.3f;

    [SerializeField] private Bullet _bullet;

    private AnimatorController _animator;

    private Coroutine _attackRoutine;
    private Transform _target;
    private int _targetLayer;

    private void Start()
    {
        _animator = GetComponentInChildren<AnimatorController>();
    }

    public void Attack(Transform target, int targetLayer)
    {
        _target = target;
        _targetLayer = targetLayer;
        transform.LookAt(_target);
        if (_attackRoutine == null)
        {
            _attackRoutine = StartCoroutine(AttackCoroutine());
        }
    }

    public void StopAttack()
    {
        if (_attackRoutine != null)
        {
            StopCoroutine(_attackRoutine);
        }
        _attackRoutine = null;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            _animator.ShootAnimation();
            Vector3 scatterAngle = transform.eulerAngles;
            scatterAngle.x = Random.Range(-10.0f, 10.0f);
            var bullet = Instantiate(_bullet, transform.TransformPoint(Vector3.forward * 1.5f), Quaternion.Euler(scatterAngle));
            bullet.TargetLayer = _targetLayer;
            var damage = this.GetComponent<Unit>().Damage;
            bullet.Damage = damage;
            yield return new WaitForSeconds(TimeRecharge);
        }
        
    }
}
