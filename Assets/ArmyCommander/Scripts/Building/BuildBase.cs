using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildBase : MonoBehaviour
{
    public int Cost = 10;
    public bool IsSold => _buyValue == 0;
    [SerializeField] private TMP_Text _costText; 
    [SerializeField] private GameObject _buildPrefab;

    private int _buyValue;

    private void Start()
    {
        _buyValue = Cost;
        _costText.text = _buyValue.ToString();
    }

    public void SoldBuild()
    {
        _buyValue--;
        _costText.text = _buyValue.ToString(); 
        if (IsSold)
        {
            var build = transform.Find("SoldiersTent");
            build.gameObject.SetActive(true);
        }
    }
}
