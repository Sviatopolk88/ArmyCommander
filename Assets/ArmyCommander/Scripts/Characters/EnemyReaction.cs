using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReaction : UnitReactionDetector
{
    private Vector3 _homePosition;

    private void Start()
    {
        _homePosition = transform.position;
    }

    protected override void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
    {
        _detectedObjects.Remove(detectedObject);

        if (_target == detectedObject)
        {
            if (_detectedObjects.Count > 0)
            {
                _target = _detectedObjects[0];
                _move.MoveTo(_target, StopDistanceAttack);
                _attack.Attack(_target.transform.position, _target.layer);
            }
            else
            {
                _attack.StopAttack();
                _move.BackToHome(_homePosition, 0);
            }
        }
    }

}
