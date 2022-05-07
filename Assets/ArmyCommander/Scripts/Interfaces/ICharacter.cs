using UnityEngine;

public interface ICharacter
{
    int damage { get; }
    float speed { get; }
    bool isDied { get; }
}
