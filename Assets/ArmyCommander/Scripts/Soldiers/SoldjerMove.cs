using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldjerMove : MonoBehaviour
{
    public Transform Point;

    private NavMeshAgent _agent;
    private Detector _detector;
    private Transform _target;
    private List<GameObject> _enemies = new List<GameObject>();

    private void Awake()
    {
        _detector = GetComponentInChildren<Detector>();
    }

    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        EventManager.OnCharacterDie.AddListener(EnemyKilled);
    }
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Move(Point.position);
    }

    private void Update()
    {
        if (_target)
        {
            transform.LookAt(_target);
        }
    }

    public void Move(Vector3 target)
    {
        _agent.SetDestination(target);
    }

    private void EnemyKilled(GameObject enemy)
    {
        if (enemy.layer == 6)
        {
            _enemies.Remove(enemy);
        }
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (_enemies.Count == 0)
        {
            _enemies.Add(detectedObject);
            _target = detectedObject.transform;
            _agent.stoppingDistance = 5;
            Move(detectedObject.transform.position);
        }
        else
        {
            _enemies.Add(detectedObject);
        }
        
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _enemies.Remove(detectedObject);
        if (_enemies.Count > 0)
        {
            _target = _enemies[0].transform;
            Move(_target.position);
        }
        else if(EnemyManager.EnemySpawner.Count > 0)
        {
            _target = EnemyManager.EnemySpawner[0];
            Move(_target.position);
        }
        else
        {
            _agent.isStopped = true;
        }
        
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
