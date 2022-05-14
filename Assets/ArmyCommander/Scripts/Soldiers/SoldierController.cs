using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierController : MonoBehaviour
{
    public UnityEvent OnSpawnerSoldierEvent;
    
    private List<GameObject> _soldiers = new List<GameObject>();
    private UnitMove _soldier;

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(RemoveSoldiersList);
    }
    public void AddSoldiersList(GameObject soldier)
    {
        _soldiers.Add(soldier);
    }

    public void RemoveSoldiersList(GameObject soldier)
    {
        if (soldier.layer == 7)
        {
            _soldiers.Remove(soldier);
            if (_soldiers.Count <= 0)
            {
                OnSpawnerSoldierEvent.Invoke();
            }
        }
    }

    public void Charge()
    {
        var target = EnemyManager.EnemySpawner[0];
        for (int i = 0; i < _soldiers.Count; i++)
        {
            _soldier = _soldiers[i].GetComponent<UnitMove>();
            _soldier.MoveTo(target.gameObject, 0);
        }
    }
}
