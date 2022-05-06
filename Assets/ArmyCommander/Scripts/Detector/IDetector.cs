using UnityEngine;

public delegate void ObjectDetectedHandler(GameObject source, GameObject detectedObject);
public interface IDetector
{
    event ObjectDetectedHandler OnGameObjectDetectedEvent;
    event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public void Detected(IDetectableObject detectableObject);
    public void ReleaseDetection(IDetectableObject detectableObject);

}
