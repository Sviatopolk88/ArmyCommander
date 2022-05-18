using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitReactionDetector : MonoBehaviour
{
    public float StopDistanceAttack = 7.0f;

    private Detector _detector;
    private List<GameObject> _detectedObjects = new List<GameObject>();
    private GameObject _target;
    private Movable _movable;
    private UnitAttack _attack;
    private int _enemyLayer = 6;

    private void Awake()
    {
        _detector = GetComponentInChildren<Detector>();
    }

    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }

    private void Start()
    {
        _movable = GetComponent<Movable>();
        _attack = GetComponent<UnitAttack>();
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == _enemyLayer)
        {
            if (_detectedObjects.Count == 0)
            {
            
                _target = detectedObject;
                _movable.MoveToAttack(_target.transform);
                _attack.Attack(_target.transform, _target.layer); //
            }
            _detectedObjects.Add(detectedObject);
        }
        
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _detectedObjects.Remove(detectedObject);

        if (_target == detectedObject)
        {
            if (_detectedObjects.Count > 0)
            {
                _target = _detectedObjects[0];
                _movable.MoveToAttack(_target.transform);
                _attack.Attack(_target.transform, _target.layer); //
            }
            else
            {
                _attack.StopAttack();
                if (EnemyManager.EnemySpawner.Count == 0)
                {
                    _movable.StopUnit();
                }
                else
                {
                    var target = EnemyManager.EnemySpawner[0];
                    _movable.MoveToAttack(target);
                }
            }
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
