using UnityEngine;

public class CharacterCoinManager : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    public void CreateCoin()
    {
        var coin = Instantiate(_coin);
        coin.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
