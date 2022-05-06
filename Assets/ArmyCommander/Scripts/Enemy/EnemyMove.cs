using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Detector _detector;
    private Vector3 _homePosition;
    private Transform _target;

    private void Awake()
    {
        _detector = GetComponentInChildren<Detector>();
    }

    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _homePosition = transform.position;
    }

    private void Update()
    {
        if (_target)
        {
            transform.LookAt(_target);
        }
    }

    private void Move(Vector3 target)
    {
        _agent.SetDestination(target);
    }
    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        _target = detectedObject.transform;
        _agent.stoppingDistance = 5;
        Move(detectedObject.transform.position);
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _target = null;
        _agent.stoppingDistance = 0;
        Move(_homePosition);
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }


}
