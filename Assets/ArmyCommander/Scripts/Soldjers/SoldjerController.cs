using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldjerController : MonoBehaviour
{
    public UnityEvent OnSpawnerSoldjerEvent;
    
    private List<GameObject> _soldiers = new List<GameObject>();
    private SoldjerMove _soldier;

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(RemoveSoldjersList);
    }
    public void AddSoldjersList(GameObject soldier)
    {
        _soldiers.Add(soldier);
    }

    public void RemoveSoldjersList(GameObject soldier)
    {
        Debug.Log(soldier);
        if (soldier.layer == 7)
        {
            _soldiers.Remove(soldier);
            if (_soldiers.Count <= 0)
            {
                OnSpawnerSoldjerEvent.Invoke();
            }
        }

    }
    public void Charge()
    {
        var target = EnemyManager.EnemySpawner[0].position;
        for (int i = 0; i < _soldiers.Count; i++)
        {
            _soldier = _soldiers[i].GetComponent<SoldjerMove>();
            _soldier.Move(target);
        }
    }
}
