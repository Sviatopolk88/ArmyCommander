using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldjerController : MonoBehaviour
{
    public static bool IsCharge = false;
    
    private List<GameObject> _soldjers = new List<GameObject>();
    private SoldjerMove _soldjer;


    public void AddSoldjersList(GameObject soldjer)
    {
        _soldjers.Add(soldjer);
    }

    public void RemoveSoldjersList(GameObject soldjer)
    {
        _soldjers.Remove(soldjer);
        if (_soldjers.Count == 0)
        {
            IsCharge = false;
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
