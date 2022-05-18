using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitsSpawner : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public float RespawnRate = 5;
    [SerializeField] private Transform _soldierPrefab;
    [SerializeField] private PlayerUnitsManager _playerUnitsManager;

    private Transform _point;
    private Coroutine _spawnerRoutine;

    private void OnEnable()
    {
        EventManager.OnAllPlayerUnitsDied.AddListener(StartSpawner);
    }

    private void Start()
    {
        if (_playerUnitsManager.NumberOfSoldiers() < Points.Count)
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
        while (_playerUnitsManager.IndexPoint() < Points.Count)
        {
            var index = _playerUnitsManager.IndexPoint();
            _point = Points[index];
            var soldier = Instantiate(_soldierPrefab);
            _playerUnitsManager.AddSoldiersList(soldier.gameObject);
            soldier.position = transform.position + Vector3.forward*2;
            soldier.GetComponent<Movable>().MoveToPoint(_point);
            yield return new WaitForSeconds(RespawnRate);
        }
    }   
}
