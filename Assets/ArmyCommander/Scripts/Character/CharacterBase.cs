using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IHittable
{
    public bool IsDied => _currentHealth <= 0;
    public int _currentHealth { get; set; }
    
    public abstract void HitObject(int damage);
}
