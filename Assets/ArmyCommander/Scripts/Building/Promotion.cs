using UnityEngine;
using TMPro;

public class Promotion : MonoBehaviour
{
    public int Cost = 30;

    public bool IsSold => _buyValue == 0;

    [SerializeField] private TMP_Text _costText;
    [SerializeField] private PlayerController _player;
    private int _buyValue;

    private void Start()
    {
        _buyValue = Cost;
        _costText.text = _buyValue.ToString();
    }

    public void PlayerPromotion()
    {
        _buyValue--;
        _costText.text = _buyValue.ToString();

        if (IsSold)
        {
            _player.Promotion();
        }
    }
}
