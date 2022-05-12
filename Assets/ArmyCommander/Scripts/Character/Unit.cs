using UnityEngine;

public class Unit : CharacterBase
{
    public int Health = 100;
    public int Damage = 5;
    public float Speed = 3f;

    [SerializeField] private BanknoteBase _banknote;

    public override void HitObject(int damage)
    {
        Health -= damage;
        if (IsDied)
        {
            EventManager.SendCharacterDie(gameObject);
            _banknote.CreateBanknote(_banknote.gameObject, transform);

            // добавить анимацию смерти

            Destroy(gameObject, 1f);
        }
    }

}
