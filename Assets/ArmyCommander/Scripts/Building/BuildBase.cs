using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildBase : MonoBehaviour
{
    public int Cost = 10;
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
    }

    public IEnumerator CreateBuild()
    {
        while(_buyValue < Cost)
        {

            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
