using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit
{
    public float TimerRestore = 5.0f;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Text _healthText;
    [SerializeField] private UIProgressBar _healthBar;
    

    private Rigidbody _rigidbody;
    private AnimatorController _playerAnimator;
    private PlayerCashManager _cash;

    private float _timer;
    private Vector3 _homePosition;
    private bool _onGround = true;

    void Start()
    {
        _homePosition = transform.position;
        _currentHealth = Health;
        _healthText.text = _currentHealth.ToString();
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponentInChildren<AnimatorController>();
        _cash = GetComponent<PlayerCashManager>();
        _healthBar.SetValue(_currentHealth, Health);
    }

    private void Update()
    {
        if (_currentHealth > 0 && _currentHealth < Health)
        {
            _timer += Time.deltaTime;
            if (_timer >= TimerRestore)
            {
                HealthRestore(5);
                _timer = 0;
            }
        }

        if (!_onGround)
        {
            _rigidbody.AddForce(Vector3.down*980);
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirectional = new Vector3(_joystick.Horizontal * Speed, 0, _joystick.Vertical * Speed);
        _rigidbody.velocity = moveDirectional;
        transform.LookAt(moveDirectional + transform.position);
        if (_rigidbody.velocity != Vector3.zero)
        {
            _playerAnimator.RunAnimation();
        }
        else
        {
            _playerAnimator.IdleAnimation();
        }
    }

    public void Promotion()
    {
        Health += 100;
        _currentHealth += 100;
        Damage += 10;
        _healthBar.SetValue(_currentHealth, Health);
        _healthText.text = _currentHealth.ToString();
    }

    public override void HitObject(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetValue(_currentHealth, Health);
        _healthText.text = _currentHealth.ToString();
        if (_isDied)
        {
            EventManager.SendCharacterDie(gameObject);
            _playerAnimator.DeathAnimation();

            Debug.Log("ГГ умер, несите нового"); // ------------

            transform.position = _homePosition;
            _currentHealth = Health;
            _healthBar.SetValue(_currentHealth, Health);
            _cash.RemoveAllBanknotes();
        }
    }

    public void HealthRestore(int restore)
    {
        _currentHealth += restore;
        if (_currentHealth > Health)
        {
            _currentHealth = Health;
        }
        _healthBar.SetValue(_currentHealth, Health);
        _healthText.text = _currentHealth.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            _onGround = false;
        }
    }
}
