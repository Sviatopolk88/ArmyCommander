using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    public void Shoot(Transform source, Transform target)
    {
        var bullet = Instantiate(_bullet);
        bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
        bullet.Target = target;
        var damage = source.GetComponentInParent<IPowerAttack>().damage;
        bullet.Damage = damage;
    }
}
