using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitsSpawner : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public float RespawnRate = 5;
    [SerializeField] private Transform _soldierPrefab;
    [SerializeField] private SoldierController _soldiers;

    private int _index;
    private Transform _point;
    private Coroutine _spawnerRoutine;


    void Start()
    {
        StartSpawner();
    }

    public void StartSpawner()
    {
        _index = 0;
        _spawnerRoutine = StartCoroutine(Spawner());
    }

    public void StopSpawner()
    {
        StopCoroutine(_spawnerRoutine);
    }
    
    private IEnumerator Spawner()
    {
        while (_index < Points.Count)
        {
            _point = Points[_index];
            _index++;
            var soldier = Instantiate(_soldierPrefab);
            _soldiers.AddSoldiersList(soldier.gameObject);
            soldier.position = transform.position;
            soldier.GetComponent<UnitMove>().MoveTo(_point.gameObject, 0.0f);
            yield return new WaitForSeconds(RespawnRate);
        }
    }
}
