using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private GameObject _textWin;
    private Transform _flag;
    private void Start()
    {
        _flag = transform.Find("Flag");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (EnemyManager.EnemySpawner.Count == 0)
            {
                FlagMove();
                if (_flag.position.y <= -0.4)
                {
                    _textWin.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }
    public void FlagMove()
    {
        _flag.position += new Vector3(0, -0.1f, 0) * Time.deltaTime;
    }
}
