using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class EnemyAttack : MonoBehaviour
{
    public float TimeRecharge = 0.3f;

    private Detector _detector;
    private Attack _attack;
    private float _timer = 0;
    private List<GameObject> _targets = new List<GameObject>();

    private Transform _source;

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
        _attack = GetComponent<Attack>();
    }
    private void Update()
    {
        if (_targets.Count > 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= TimeRecharge)
            {
                _attack.Shoot(this.transform, _targets[0].transform);
                _timer = 0;
            }
        }
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (!_targets.Contains(detectedObject))
        {
            _targets.Add(detectedObject);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _targets.Remove(detectedObject);
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
