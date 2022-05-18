using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _smooth = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _cameraPosition;

    private void Start()
    {
        transform.position = _player.transform.position + new Vector3(-5.6f, 15f, -8.2f);
    }

    private void Update()
    {
        _cameraPosition = _player.transform.position + new Vector3(-5.6f, 15f, -8.2f);
        transform.position = Vector3.SmoothDamp(transform.position, _cameraPosition, ref _velocity, _smooth);
    }
}
