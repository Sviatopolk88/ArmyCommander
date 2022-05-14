using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitReactionDetector : MonoBehaviour
{
    public float StopDistanceAttack = 7.0f;

    private Detector _detector;
    private List<GameObject> _detectedObjects = new List<GameObject>();
    private GameObject _target;
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
        if (_detectedObjects.Count == 0)
        {
            _target = detectedObject;
            _move.MoveTo(_target, StopDistanceAttack);
            _attack.Attack(_target.transform.position, _target.layer);
        }
        _detectedObjects.Add(detectedObject);
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _detectedObjects.Remove(detectedObject);

        if (_target == detectedObject)
        {
            if (_detectedObjects.Count > 0)
            {
                _target = _detectedObjects[0];
                _move.MoveTo(_target, StopDistanceAttack);
                _attack.Attack(_target.transform.position, _target.layer);
            }
            else
            {
                _attack.StopAttack();
                _move.BackToHome(_homePosition, 0);
            }
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
