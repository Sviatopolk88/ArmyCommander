using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitsSpawner : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public float RespawnRate = 5;
    [SerializeField] private Transform _soldierPrefab;
    [SerializeField] private PlayerUnitsManager _soldiersManager;

    private Transform _point;
    private Coroutine _spawnerRoutine;

    private void OnEnable()
    {
        EventManager.OnAllPlayerUnitsDied.AddListener(StartSpawner);
    }

    private void Start()
    {
        if (_soldiersManager.NumberOfSoldiers() < Points.Count)
        {
            StartSpawner();
        }
    }

    public void StartSpawner()
    {
        _spawnerRoutine = StartCoroutine(Spawner());
    }

    public void StopSpawner()
    {
        StopCoroutine(_spawnerRoutine);
    }
    
    private IEnumerator Spawner()
    {
        while (_soldiersManager.IndexPoint() < Points.Count)
        {
            var index = _soldiersManager.IndexPoint();
            _point = Points[index];
            var soldier = Instantiate(_soldierPrefab);
            _soldiersManager.AddSoldiersList(soldier.gameObject);
            soldier.position = transform.position + Vector3.forward*2;
            soldier.GetComponent<Movable>().MoveToPoint(_point.position);
            //soldier.GetComponent<UnitMove>().MoveTo(_point.gameObject, 0);
            yield return new WaitForSeconds(RespawnRate);
        }
    }
}
