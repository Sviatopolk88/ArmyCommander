using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<GameObject> OnCharacterDie = new UnityEvent<GameObject>();

    public static void SendCharacterDie(GameObject enemy)
    {
        OnCharacterDie.Invoke(enemy);
    }

}
