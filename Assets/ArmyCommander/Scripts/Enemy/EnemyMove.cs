using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : UnitMove
{
    private Vector3 _homePosition;

    private void Start()
    {
        _homePosition = transform.position;
    }
    
    void Update()
    {
        float dist = Vector3.Distance(_homePosition, transform.position);
        Debug.Log(dist);
        /*
        if (Vector3.Distance(_homePosition, transform.position) > 10)
        {
            BackToHome(_homePosition, 0);
        }
        */
    }
}
