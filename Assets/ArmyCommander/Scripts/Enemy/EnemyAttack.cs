using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /*
    public float TimeRecharge = 0.3f;

    private Detector _detector;
    private Shot _attack;
    private float _timer = 0;
    private List<GameObject> _targets = new List<GameObject>();
    private GameObject _target;

    private Transform _source;

    private void Awake()
    {
        _detector = GetComponentInChildren<Detector>();
    }
    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        EventManager.OnCharacterDie.AddListener(PlayerKilled);
    }

    private void Start()
    {
        _attack = GetComponent<Shot>();
    }
    private void Update()
    {
        if (_targets.Count > 0)
        {
            _target = _targets[0];
            _timer += Time.deltaTime;
            if (_timer >= TimeRecharge && _targets[0] != null)
            {
                _attack.SimpleShot(this.transform, _targets[0].transform);
                _timer = 0;

            }
        }
    }

    private void PlayerKilled(GameObject player)
    {
        _detector.ReleaseDetection(player.GetComponent<IDetectableObject>());
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
    */
}
