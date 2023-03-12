using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorReaction : MonoBehaviour
{
    private GameObject _enemyDetectionZone;
    private GameObject _banknoteDetectionZone;
    private Detector _enemyDetector;
    private Detector _banknoteDetector;

    private PlayerAttack _attack;
    private PlayerCashManager _playerCash;

    private void Awake()
    {
        _enemyDetectionZone = transform.Find("EnemyDetectionZone").gameObject;
        _banknoteDetectionZone = transform.Find("BanknoteDetectionZone").gameObject;
        _enemyDetector = _enemyDetectionZone.GetComponentInChildren<Detector>();
        _banknoteDetector = _banknoteDetectionZone.GetComponentInChildren<Detector>();
    }

    private void OnEnable()
    {
        _enemyDetector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _enemyDetector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        _banknoteDetector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _banknoteDetector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }

    private void Start()
    {
        _attack = GetComponent<PlayerAttack>();
        _playerCash = GetComponent<PlayerCashManager>();
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        //Если заметил врага
        if (source == _enemyDetectionZone && detectedObject.layer == 6)
        {
            _attack.AddEnemyList(detectedObject);
        }

        //Подбор монеток
        if (source == _banknoteDetectionZone && detectedObject.layer == 9)
        {
            _playerCash.AddBanknoteList(detectedObject);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        //Если враг вне зоны детектора
        if (source == _enemyDetectionZone && detectedObject.layer == 6)
        {
            _attack.RemoveEnemyList(detectedObject);
        }
        // Монетки вне зоны детектора
        if (source == _banknoteDetectionZone && detectedObject.layer == 9)
        {
            _playerCash.RemoveBanknoteList(detectedObject);
        }
    }

    private void OnDisable()
    {
        _enemyDetector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _enemyDetector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        _banknoteDetector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _banknoteDetector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }
}
