using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCashManager : MonoBehaviour
{
    [SerializeField] private Transform _banknote;
    [SerializeField] private Text _goldBanknote;
    [SerializeField] private Text _silverBanknote;

    private Vector3 _banknotePosition = new Vector3(0, 0, -0.7f);
    private List<GameObject> _playerBanknotes = new List<GameObject>();
    private List<GameObject> _banknotes = new List<GameObject>();
    private DetectableObject _detector;
    private BuildBase _planeBuilding;
    private Rigidbody _rb;
    private Coroutine _saleRoutine;
    private Coroutine _addBanknoteRoutine;
    private AudioSource _changeBanknoteSound;

    private void Awake()
    {
        _detector = GetComponent<DetectableObject>();
        _rb = GetComponent<Rigidbody>();
        _goldBanknote.text = _playerBanknotes.Count.ToString();
        _silverBanknote.text = _playerBanknotes.Count.ToString();
        _changeBanknoteSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _detector.OnGameObjectDetectedEvent += OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
    }

    private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
    {
        if (detectedObject.layer == 10 && source.layer == 9)
        {
            _banknotes.Add(source);
            if (_addBanknoteRoutine == null)
            {
                _addBanknoteRoutine = StartCoroutine(AddBanknote());
            }
        }

        if (source.layer == 8)
        {
            if (_playerBanknotes.Count > 0)
            {
                _planeBuilding = source.GetComponent<BuildBase>();
                if (!_planeBuilding.IsSold)
                {
                    _saleRoutine = StartCoroutine(IsStayPlayer());
                }
            }
        }
    }

    private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        if (source.layer == 10 && detectedObject.layer == 9)
        {
            _banknotes.Remove(source);
        }

        if (source.layer == 8)
        {
            if (_saleRoutine != null)
            {
                StopCoroutine(_saleRoutine);
            }
        }
    }

    private IEnumerator IsStayPlayer()
    {
        while (true && _playerBanknotes.Count > 0 && _planeBuilding.IsSold == false)
        {
            if (_rb.velocity == Vector3.zero)
            {
                _planeBuilding.SoldBuild();
                RemoveBanknote();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnDisable()
    {
        _detector.OnGameObjectDetectedEvent -= OnGameObjectDetected;
        _detector.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
    }

    public IEnumerator AddBanknote()
    {
        while (_banknotes.Count > 0)
        {
            var currentCoin = Instantiate(_banknote, transform);
            currentCoin.position = transform.TransformPoint(_banknotePosition);
            _playerBanknotes.Add(currentCoin.gameObject);
            _banknotePosition += new Vector3(0, 0.1f, 0);

            int lastBanknote = _banknotes.Count - 1;
            var banknote = _banknotes[lastBanknote];
            Destroy(banknote);
            _banknotes.RemoveAt(lastBanknote);
            _goldBanknote.text = _playerBanknotes.Count.ToString();

            _changeBanknoteSound.Play();
            yield return new WaitForSeconds(0.1f);
        }
        _addBanknoteRoutine = null;
    }

    public void RemoveBanknote()
    {
        if(_playerBanknotes.Count > 0)
        {
            Destroy(_playerBanknotes[_playerBanknotes.Count - 1]);
            _playerBanknotes.RemoveAt(_playerBanknotes.Count - 1);
            _goldBanknote.text = _playerBanknotes.Count.ToString();
            _banknotePosition -= new Vector3(0, 0.1f, 0);
            _changeBanknoteSound.Play();
        }
    }

    public void RemoveAllBanknotes()
    {
        int allBanknotes = _playerBanknotes.Count;
        for (int i = 0; i < allBanknotes; i++)
        {
            RemoveBanknote();
        }
        _goldBanknote.text = _playerBanknotes.Count.ToString();
    }
}
