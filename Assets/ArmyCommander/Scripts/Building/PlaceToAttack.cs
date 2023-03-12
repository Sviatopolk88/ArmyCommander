using System;
using UnityEngine;

public class PlaceToAttack : MonoBehaviour
{
    [SerializeField] private GameObject _buttonAttack;
    [SerializeField] private PlayerUnitsManager _soldiersManager;
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

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == 10 && !_soldiersManager.IsAttacking())
        {
            _buttonAttack.SetActive(true);
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == 10)
        {
            _buttonAttack.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }
}
