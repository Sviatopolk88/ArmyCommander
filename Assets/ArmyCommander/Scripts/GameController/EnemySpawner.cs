using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int CountEnemies = 8;
    [SerializeField] private Transform _enemyPrefab;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < CountEnemies; i++)
        {
            var enemy = Instantiate(_enemyPrefab, this.transform);
            if (i > (CountEnemies / 2) - 1)
            {
                var j = CountEnemies - i;
                enemy.position += new Vector3(2 * (j-1), 0, 2);
            }
            else
            {
                enemy.position += new Vector3(2 * i, 0, 0);
            }
            
        }
    }
}
