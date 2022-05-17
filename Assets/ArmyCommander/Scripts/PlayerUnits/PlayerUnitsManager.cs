using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUnitsManager : MonoBehaviour
{
    private List<GameObject> _soldiers = new List<GameObject>();
    private UnitMove _soldier;
    private bool _isSoldiersInAttack = false;
    private int _indexPoint = 0;

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(RemoveSoldiersList);
    }
    
    public int IndexPoint()
    {
        return _indexPoint;
    }

    public int NumberOfSoldiers()
    {
        return _soldiers.Count;
    }
    
    public void AddSoldiersList(GameObject soldier)
    {
        _soldiers.Add(soldier);
        _indexPoint++;
    }

    public void RemoveSoldiersList(GameObject soldier)
    {
        if (soldier.layer == 7)
        {
            _soldiers.Remove(soldier);
            if (_soldiers.Count <= 0)
            {
                _isSoldiersInAttack = false;
                _indexPoint = 0;
                EventManager.OnAllPlayerUnitsDied.Invoke();
            }
        }
    }

    public void Charge()
    {
        if (!_isSoldiersInAttack)
        {
            _isSoldiersInAttack = true;
            var target = EnemyManager.EnemySpawner[0];
            for (int i = 0; i < _soldiers.Count; i++)
            {
                _soldier = _soldiers[i].GetComponent<UnitMove>();
                _soldier.MoveTo(target.gameObject, 0);
            }
        }
    }
}
