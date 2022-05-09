using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, ICharacter, IHittable, IPowerAttack
{
    public int Health = 100;
    public int Damage = 5;
    public float Speed = 3f;
    public int health => Health;
    public int damage => Damage;
    public float speed => Speed;

    public bool isDied => Health <= 0;

    private CharacterCoinManager _coin;

    private void Start()
    {
        _coin = GetComponent<CharacterCoinManager>();
    }

    public void HitObject(int damage)
    {
        Health -= damage;
        if (isDied)
        {
            EventManager.SendCharacterDie(gameObject);
            _coin.CreateCoin();
            Destroy(gameObject);
        }
    }
}
