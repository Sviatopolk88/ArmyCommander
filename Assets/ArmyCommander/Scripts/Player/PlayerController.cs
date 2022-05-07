using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter, IHittable, IPowerAttack
{
    //public float Speed = 5f;
    public int MaxHealth = 100;
    public int Damage = 10;
    public int damage => Damage;

    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigidbody;
    
    private int _health;

    public float speed => 5f;

    public bool isDied => _health <= 0;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = MaxHealth;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * speed, 0, _joystick.Vertical * speed);
    }
    public void HitObject(int damage)
    {
        _health -= damage;
        if (isDied)
        {
            EventManager.SendCharacterDie(gameObject);
            Destroy(gameObject, 0.3f);
            Debug.Log("ГГ умер, несите нового"); // Добавить скрипт респавна
        }
            
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
