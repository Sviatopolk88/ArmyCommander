using System.Collections;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public float TimeRecharge = 0.3f;

    [SerializeField] private Bullet _bullet;

    private Coroutine _attackRoutine;

    public void Attack(GameObject target)
    {
        _attackRoutine = StartCoroutine(AttackCoroutine(target));
    }

    public void StopAttack()
    {
        StopCoroutine(_attackRoutine);
    }

    private IEnumerator AttackCoroutine(GameObject target)
    {
        var bullet = Instantiate(_bullet);
        bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
        bullet.Target = target.transform;
        var damage = this.GetComponent<Unit>().Damage;
        Debug.Log("Damage = " + damage);
        bullet.Damage = damage;
        yield return new WaitForSeconds(TimeRecharge);
    }
}
