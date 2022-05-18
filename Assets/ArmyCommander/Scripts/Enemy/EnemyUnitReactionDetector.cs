using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitReactionDetector : MonoBehaviour
{
    public float StopDistanceAttack = 7.0f;

    private Detector _detector;
    private List<GameObject> _detectedObjects = new List<GameObject>();
    private GameObject _currentTarget;
    private UnitMove _move;
    private UnitAttack _attack;
    private Movable _movable;
    private Vector3 _homePosition;
    private int _playerLayer = 10;
    private int _playerUnits = 7;

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
        _move = GetComponent<UnitMove>();
        _movable = GetComponent<Movable>();
        _attack = GetComponent<UnitAttack>();
        _homePosition = transform.position;
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == _playerLayer || detectedObject.layer == _playerUnits)
        {
            if (_detectedObjects.Count == 0)
            {
                _currentTarget = detectedObject;
                _movable.MoveToAttack(_currentTarget.transform);
                _attack.Attack(_currentTarget.transform, _currentTarget.layer); //
            }
            _detectedObjects.Add(detectedObject);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _detectedObjects.Remove(detectedObject);

        if (_currentTarget == detectedObject)
        {
            if (_detectedObjects.Count > 0)
            {
                _currentTarget = _detectedObjects[0];
                _movable.MoveToAttack(_currentTarget.transform);
                _attack.Attack(_currentTarget.transform, _currentTarget.layer); //
            }
            else
            {
                _attack.StopAttack();
                _movable.BackToHome();
            }
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
