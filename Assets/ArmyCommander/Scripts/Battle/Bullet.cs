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
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
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
