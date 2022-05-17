using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitReactionDetector : MonoBehaviour
{
    /*
    public float StopDistanceAttack = 7.0f;

    protected Detector _detector;
    protected List<GameObject> _detectedObjects = new List<GameObject>();
    protected GameObject _target;
    protected UnitMove _move;
    protected UnitAttack _attack;

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

    protected virtual void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
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
                if (EnemyManager.EnemySpawner.Count == 0)
                {
                    _move.StopUnit();
                }
                else
                {
                    var target = EnemyManager.EnemySpawner[0];
                    _move.MoveTo(target.gameObject, StopDistanceAttack);
                }
            }
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
    */
}
