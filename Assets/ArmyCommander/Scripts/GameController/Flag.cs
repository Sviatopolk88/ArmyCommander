using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Transform _flag;
    private Detector _detector;

    private void Awake()
    {
        _detector = GetComponent<Detector>();
    }

    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }
    void Start()
    {
        _flag = transform.Find("Flag");
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == 7)
        {
            if (EnemyManager.EnemySpawner.Count == 0)
            {

            }
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }


    
    public void FlagMove()
    {
        _flag.position += new Vector3(0, -0.1f, 0);
    }
}
