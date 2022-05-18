using UnityEngine;

public class HealthbarOrientation : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    void Update()
    {
        transform.LookAt(_camera);
    }
}