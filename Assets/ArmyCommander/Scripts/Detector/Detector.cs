using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour, IDetector
{
    public event ObjectDetectedHandler OnGameObjectDetectedEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    private List<GameObject> _detectedObjects = new List<GameObject>();

    private void Start()
    {
        EventManager.OnCharacterDie.AddListener(DeathDetectableObject);
    }

    private void DeathDetectableObject(GameObject detectableObject)
    {
        IDetectableObject target = detectableObject.GetComponent<IDetectableObject>();
        if (target != null)
            ReleaseDetection(target);
    }

    public void Detected(IDetectableObject detectableObject)
    {
        if(detectableObject.gameObject.layer != gameObject.layer)
        {
            if (!_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(gameObject);
                _detectedObjects.Add(detectableObject.gameObject);
            
                OnGameObjectDetectedEvent?.Invoke(gameObject, detectableObject.gameObject);
            }
        }
    }

    public void ReleaseDetection(IDetectableObject detectableObject)
    {
        if (_detectedObjects.Contains(detectableObject.gameObject))
        {
            detectableObject.DetectionReleased(gameObject);
            _detectedObjects.Remove(detectableObject.gameObject);

            OnGameObjectDetectionReleasedEvent?.Invoke(gameObject, detectableObject.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderDetectableObject(other, out var detectableObject))
        {
            Detected(detectableObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsColliderDetectableObject(other, out var detectableObject))
        {
            ReleaseDetection(detectableObject);
        }
    }

    private bool IsColliderDetectableObject(Collider coll, out IDetectableObject detectableObject)
    {
        detectableObject = coll.GetComponent<IDetectableObject>();
        return detectableObject != null;
    }
}
