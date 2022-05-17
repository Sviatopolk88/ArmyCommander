using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _smooth = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _cameraPosition;

    void Update()
    {
        _cameraPosition = _player.transform.position + new Vector3(-6f, 18f, -8f);
        transform.position = Vector3.SmoothDamp(transform.position, _cameraPosition, ref _velocity, _smooth);
    }
}
