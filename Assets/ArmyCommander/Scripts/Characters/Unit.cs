using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour, IHittable
{
    public int Health = 100;
    public int Damage = 5;
    public float Speed = 3f;

    private AnimatorController _animator;
    private Movable _moveAction;
    private UnitAttack _attackAction;
    private IEnumerator _routine;

    protected int _currentHealth;
    protected bool _isDied => _currentHealth <= 0;

    [SerializeField] private BanknoteBase _banknote;

    private void Start()
    {
        _currentHealth = Health;
        _animator = GetComponentInChildren<AnimatorController>();
        _moveAction = GetComponent<Movable>();
        _attackAction = GetComponent<UnitAttack>();
    }

    public virtual void HitObject(int damage)
    {
        _currentHealth -= damage;
        if (_isDied && _routine == null)
        {
            _routine = DeathUnit();
            StartCoroutine(_routine);
        }
    }

    private IEnumerator DeathUnit()
    {
        _attackAction.StopAttack();
        _moveAction.StopUnit();
        _animator.DeathAnimation();
        
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
        _banknote.CreateBanknote(_banknote.gameObject, transform);
    }

    private void OnDisable()
    {
        EventManager.SendCharacterDie(gameObject);
    }

}
