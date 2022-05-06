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
    
    private Detector _detector;

    public event CharacterDieHandler OnCharacterDieEvent;

    private void Start()
    {
        _detector = GetComponentInChildren<Detector>();
    }

    public void HitObject(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnCharacterDieEvent?.Invoke(gameObject);
            Destroy(gameObject);
        }
            
    }


}
