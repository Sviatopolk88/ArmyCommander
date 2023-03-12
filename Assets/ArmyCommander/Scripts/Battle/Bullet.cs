using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public int TargetLayer;

    private int _gorundLayer = 11;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * Speed;
        Destroy(gameObject, 2f); 
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
            Destroy(gameObject);
            // Анимация попадания пули в землю
        }
    }
}
