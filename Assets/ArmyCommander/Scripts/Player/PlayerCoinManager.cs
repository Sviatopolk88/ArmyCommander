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

    private void Awake()
    {
        _detectableObject = GetComponent<DetectableObject>();
    }

    private void OnEnable()
    {
        _detectableObject.OnGameObjectDetectedEvent += OnGameObjectDetected;
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (source.layer == 9)
        {
            AddCoin();
            Destroy(source);
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
