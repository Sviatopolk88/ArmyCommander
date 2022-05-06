using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IHittable, IPowerAttack
{
    public int Health = 100;
    public float Speed = 3f;
    public int Damage = 5;

    public int damage => Damage;

    public void HitObject(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Destroy(gameObject);
    }


}
