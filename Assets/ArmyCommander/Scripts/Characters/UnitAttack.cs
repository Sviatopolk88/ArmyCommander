using System.Collections;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public float TimeRecharge = 0.3f;

    [SerializeField] private Bullet _bullet;

    private Coroutine _attackRoutine;
    private Vector3 _target;
    private int _targetLayer;

    public void Attack(Vector3 target, int targetLayer)
    {
        _target = target;
        _targetLayer = targetLayer;
        if (_attackRoutine == null)
        {
            _attackRoutine = StartCoroutine(AttackCoroutine());
        }
    }

    public void StopAttack()
    {
        StopCoroutine(_attackRoutine);
        _attackRoutine = null;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var bullet = Instantiate(_bullet);
            bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            bullet.Target = _target;
            bullet.TargetLayer = _targetLayer;
            var damage = this.GetComponent<Unit>().Damage;
            bullet.Damage = damage;
            yield return new WaitForSeconds(TimeRecharge);
        }
        
    }
}
