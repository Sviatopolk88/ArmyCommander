using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldjerController : MonoBehaviour
{
    public UnityEvent OnSpawnerSoldjerEvent;
    
    private List<GameObject> _soldjers = new List<GameObject>();
    private SoldjerMove _soldjer;

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(RemoveSoldjersList);
    }
    public void AddSoldjersList(GameObject soldjer)
    {
        _soldjers.Add(soldjer);
    }

    public void RemoveSoldjersList(GameObject soldjer)
    {
        Debug.Log(soldjer);
        if (soldjer.layer == 7)
        {
            _soldjers.Remove(soldjer);
            if (_soldjers.Count <= 0)
            {
                OnSpawnerSoldjerEvent.Invoke();
            }
        }

    }
    public void Charge()
    {
        var target = EnemyManager.EnemySpawner[0].position;
        for (int i = 0; i < _soldjers.Count; i++)
        {
            _soldjer = _soldjers[i].GetComponent<SoldjerMove>();
            _soldjer.Move(target);
        }
    }
}
