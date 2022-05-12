using UnityEngine;

public class PlayerController : CharacterBase
{
    public int MaxHealth = 100;
    public int Damage = 10;
    public float Speed = 5f;
    
    [SerializeField] private Joystick _joystick;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * Speed, 0, _joystick.Vertical * Speed);
    }
    public override void HitObject(int damage)
    {
        _currentHealth -= damage;
        if (IsDied)
        {
            EventManager.SendCharacterDie(gameObject);
            Destroy(gameObject, 0.3f);
            Debug.Log("ГГ умер, несите нового"); // Добавить скрипт респавна
        }
    }

    public void HealthRestore(int restore)
    {
        if (_currentHealth < MaxHealth)
        {
            _currentHealth += restore;
        }
        else
        {
            _currentHealth = MaxHealth;
        }
    }
}
