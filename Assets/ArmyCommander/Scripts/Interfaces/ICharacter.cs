using UnityEngine;

public delegate void CharacterDieHandler(GameObject destroyObject);
public interface ICharacter
{
    event CharacterDieHandler OnCharacterDieEvent;
    int health { get; }
    int damage { get; }
    float speed { get; }

}
