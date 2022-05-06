using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class PlayerAttack : MonoBehaviour
{
    public float TimerRecharge = 0.3f;

    private DetectableObject _detectableObject;
    private Attack _attack;
    private float _timer = 0;
    private List<GameObject> _enemies = new List<GameObject>();

    private Transform _source;

    private void Awake()
    {
        _detectableObject = GetComponent<DetectableObject>();
        
    }

    private void OnEnable()
    {
        _detectableObject.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }

    private void Start()
    {
        _attack = GetComponent<Attack>();
    }

    private void Update()
    {
        if (_enemies.Count > 0)
        {
            transform.LookAt(_enemies[0].transform);
            _timer += Time.deltaTime;
            if (_timer >= TimerRecharge)
            {
                _attack.Shoot(this.transform, _enemies[0].transform);
                _timer = 0;
            }
        }
    }
    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (!_enemies.Contains(source))
        {
            _enemies.Add(source);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _enemies.Remove(detectedObject);
    }

    private void OnDisable()
    {
        _detectableObject.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }


}
