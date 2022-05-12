using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitReactionDetector : MonoBehaviour
{
    public float StopDistanceAttack = 7.0f;

    private Detector _detector;
    private List<GameObject> _detectedObjects = new List<GameObject>();
    private UnitMove _move;
    private UnitAttack _attack;
    private Vector3 _homePosition;

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
        _attack = GetComponent<UnitAttack>();
        _homePosition = transform.position;
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        _detectedObjects.Add(detectedObject);
        if (_detectedObjects.Count == 1)
        {
            _move.MoveTo(_detectedObjects[0], StopDistanceAttack);
            _attack.Attack(detectedObject);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        if (_detectedObjects[0] == detectedObject)
        {
            if (_detectedObjects.Count > 1)
            {
                var target = _detectedObjects[1];
                _move.MoveTo(target, StopDistanceAttack);
                _attack.Attack(target);
            }
            else
            {
                _attack.StopAttack();
                _move.BackToHome(_homePosition, 0);
            }
        }
        _detectedObjects.Remove(detectedObject);
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
