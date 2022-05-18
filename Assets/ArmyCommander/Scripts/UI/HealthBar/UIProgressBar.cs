using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] Image imgFiller;

    public void SetValue(int currentValue, int maxValue)
    {
        imgFiller.fillAmount = (float)currentValue / maxValue;
    }
}
