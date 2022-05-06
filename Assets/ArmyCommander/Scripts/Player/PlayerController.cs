using UnityEngine;

public class PlayerController : MonoBehaviour, IHittable
{
    public float Speed = 5f;
    public int MaxHealth = 100;

    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigidbody;
    private int _health;
    private bool _isDead => _health <= 0;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = MaxHealth;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * Speed, 0, _joystick.Vertical * Speed);
    }
    public void HitObject(int damage)
    {
        _health -= damage;
        if (_isDead) Debug.Log("ГГ умер, несите нового");
    }

    public void HealthRestore(int restore)
    {
        if (_health < MaxHealth)
        {
            _health += restore;
        }
        else
        {
            _health = MaxHealth;
        }
    }
}
