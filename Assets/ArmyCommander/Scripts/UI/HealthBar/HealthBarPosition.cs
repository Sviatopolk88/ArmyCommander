using UnityEngine;

public class HealthBarPosition : MonoBehaviour
{
    public Transform Unit;

    void Update()
    {
        transform.position = Unit.position + new Vector3(0, 0.5f, 0);
    }
}
