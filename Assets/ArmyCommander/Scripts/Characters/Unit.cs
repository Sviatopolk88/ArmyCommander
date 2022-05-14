using UnityEngine;

public class Unit : MonoBehaviour, IHittable
{
    public int Health = 100;
    public int Damage = 5;
    public float Speed = 3f;

    private int _currentHealth;
    private bool _isDied => _currentHealth <= 0;

    [SerializeField] private BanknoteBase _banknote;

    private void Start()
    {
        _currentHealth = Health;
    }

    public void HitObject(int damage)
    {
        _currentHealth -= damage;

        if (_isDied)
        {
            EventManager.SendCharacterDie(gameObject);
            _banknote.CreateBanknote(_banknote.gameObject, transform);

            // добавить анимацию смерти

            Destroy(gameObject);
        }
    }

}
