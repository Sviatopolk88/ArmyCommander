using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /*
    public float TimerRecharge = 0.3f;

    private Detector _detector;
    private Shot _attack;
    private float _timer = 0;
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

    private void Start()
    {
        _attack = GetComponent<Shot>();
    }

    private void Update()
    {
        
        if (_enemies.Count > 0)
        {
            transform.LookAt(_enemies[0].transform);
            _timer += Time.deltaTime;
            if (_timer >= TimerRecharge)
            {
                _attack.SimpleShot(this.transform, _enemies[0].transform);
                _timer = 0;
            }
        }
        
    }

    private void EnemyKilled(GameObject enemy)
    {
        _detector.ReleaseDetection(enemy.GetComponent<IDetectableObject>());
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (!_enemies.Contains(detectedObject))
        {
            _enemies.Add(detectedObject);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _enemies.Remove(detectedObject);
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
    */
}
