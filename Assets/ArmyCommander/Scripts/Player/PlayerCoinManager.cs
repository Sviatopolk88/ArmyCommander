using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinManager : MonoBehaviour
{
    [SerializeField] private Transform _coin;
    private Vector3 _coinPosition = new Vector3(0, 0, -0.7f);
    private List<GameObject> _coins = new List<GameObject>();
    private DetectableObject _detectableObject;
    private BuildBase _planeBuilding;
    private Rigidbody _rb;
    private Coroutine _soldRoutine;

    private void Awake()
    {
        _detectableObject = GetComponent<DetectableObject>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _detectableObject.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (source.layer == 9)
        {
            AddCoin();
            Destroy(source);
        }

        if (source.layer == 8)
        {
            if (_coins.Count > 0)
            {
                _planeBuilding = source.GetComponent<BuildBase>();
                if (!_planeBuilding.IsSold)
                {
                    _soldRoutine = StartCoroutine(IsStayPlayer());
                }
            }
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        if (source.layer == 8)
        {
            if (_soldRoutine != null)
            {
                StopCoroutine(_soldRoutine);
            }
        }
    }

    private IEnumerator IsStayPlayer()
    {
        while (true && _coins.Count > 0 && _planeBuilding.IsSold == false)
        {
            if (_rb.velocity == Vector3.zero)
            {
                _planeBuilding.SoldBuild();
                RemoveCoin();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDisable()
    {
        _detectableObject.OnGameObjectDetectedEvent -= OnGameObjectDetected;
    }

    public void AddCoin()
    {
        var currentCoin = Instantiate(_coin, transform);
        currentCoin.position = transform.TransformPoint(_coinPosition);
        _coins.Add(currentCoin.gameObject);
        _coinPosition += new Vector3(0, 0.1f, 0);
    }

    public void RemoveCoin()
    {
        if(_coins.Count > 0)
        {
            Destroy(_coins[_coins.Count - 1]);
            _coins.RemoveAt(_coins.Count - 1);
            _coinPosition -= new Vector3(0, 0.1f, 0);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            AddCoin();
        if (Input.GetKeyDown(KeyCode.D))
            RemoveCoin();
    }
}
