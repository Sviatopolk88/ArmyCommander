using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public float TimerRecharge = 0.3f;

    private Detector _detector;
    private UnitAttack _attack;
    private float _timer = 0;
    private List<GameObject> _enemies = new List<GameObject>();
    private int _enemyLayer = 6;

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
        _attack = GetComponent<UnitAttack>();
    }

    private void Update()
    {
        
        if (_enemies.Count > 0)
        {
            var enemy = _enemies[0].transform;
            transform.LookAt(enemy);
            _timer += Time.deltaTime;
            if (_timer >= TimerRecharge)
            {
                _attack.Attack(enemy, enemy.gameObject.layer);
                _timer = 0;
            }
        }
        else
        {
            _attack.StopAttack();
        }
        
    }

    private void EnemyKilled(GameObject enemy)
    {
        _detector.ReleaseDetection(enemy.GetComponent<DetectableObject>());
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == _enemyLayer)
        {
            if (!_enemies.Contains(detectedObject))
            {
                _enemies.Add(detectedObject);
            }
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
    
}
