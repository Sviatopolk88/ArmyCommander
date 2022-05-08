using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldjerSpawner : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    [SerializeField] private Transform _soldjerPrefab;
    [SerializeField] private SoldjerController _soldjers;

    private int _index = 0;
    private Transform _point;
    private Coroutine _spawnerRoutine;

    void Start()
    {
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
            var soldjer = Instantiate(_soldjerPrefab);
            soldjer.GetComponent<SoldjerMove>().Point = _point;
            soldjer.position = transform.position;
            _soldjers.AddSoldjersList(soldjer.gameObject);
            yield return new WaitForSeconds(1);
        }
    }
}
