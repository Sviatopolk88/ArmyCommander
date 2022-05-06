using UnityEngine;

public class DetectableObject : MonoBehaviour, IDetectableObject
{
    public event ObjectDetectedHandler OnGameObjectDetectedEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public void Detected(GameObject detectionSource)
    {
        OnGameObjectDetectedEvent?.Invoke(detectionSource, gameObject);
    }

    public void DetectionReleased(GameObject detectionSource)
    {
        OnGameObjectDetectionReleasedEvent?.Invoke(detectionSource, gameObject);
    }
}
