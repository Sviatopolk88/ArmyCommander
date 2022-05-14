using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public Vector3 Target;
    public int Damage;
    public int TargetLayer;

    private int _gorundLayer = 11;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce((Target - transform.position) * Speed);
        Destroy(gameObject, 3f); // Уменьшить время самоуничтожения
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == TargetLayer)
        {
            IHittable hitObject = other.gameObject.GetComponent<IHittable>();
            if (hitObject != null)
            {
                hitObject.HitObject(Damage);

                Destroy(gameObject);
            }
        }
        else if(other.gameObject.layer == _gorundLayer)
        {
            Destroy(gameObject, 0.1f);
            // Анимация попадания пули в землю
        }
    }
}
