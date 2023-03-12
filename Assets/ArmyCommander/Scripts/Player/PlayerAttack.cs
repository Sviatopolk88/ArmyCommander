using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float TimerRecharge = 0.3f;

    private UnitAttack _attack;
    private float _timer = 0;
    private List<GameObject> _enemies = new List<GameObject>();

    private void Start()
    {
        _attack = GetComponent<UnitAttack>();
    }

    private void Update()
    {

        if (_enemies.Count > 0)
        {
            var enemy = _enemies[0].transform;
            transform.LookAt(enemy);
            _timer += Time.deltaTime;
            if (_timer >= TimerRecharge)
            {
                _attack.Attack(enemy, enemy.gameObject.layer);
                _timer = 0;
            }
        }
        else
        {
            _attack.StopAttack();
        }

    }

    public void AddEnemyList(GameObject enemy)
    {
        if (!_enemies.Contains(enemy))
        {
            _enemies.Add(enemy);
        }
    }

    public void RemoveEnemyList(GameObject enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
        }
    }
}
