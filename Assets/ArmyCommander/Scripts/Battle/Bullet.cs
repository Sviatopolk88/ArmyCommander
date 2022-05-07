using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    public int Damage;
    
    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        Destroy(gameObject, 1f); // Уменьшить время самоуничтожения
    }

    private void OnTriggerEnter(Collider other)
    {
        IHittable hitObject = other.gameObject.GetComponent<IHittable>();
        if (hitObject != null)
        {
            hitObject.HitObject(Damage);

            Destroy(gameObject, 0.1f);
        }
    }
}
