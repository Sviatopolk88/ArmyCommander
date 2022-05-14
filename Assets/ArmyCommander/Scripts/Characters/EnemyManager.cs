using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int _enemyCount;

    public static List<Transform> EnemySpawner = new List<Transform>();

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(EnemyKilled);
    }
    private void Start()
    {
        var spawnerGroup = transform.childCount;
        for(int i = 0; i < spawnerGroup; i++)
        {
            var enemySoldjer = transform.GetChild(i);
            for (int j = 0; j < enemySoldjer.childCount; j++)
            {
                EnemySpawner.Add(enemySoldjer.GetChild(j));
            }
        }
    }

    private void EnemyKilled(GameObject enemy)
    {
        if (enemy.layer == 6)
        {
            EnemySpawner.Remove(enemy.transform);
        }
    }
}
