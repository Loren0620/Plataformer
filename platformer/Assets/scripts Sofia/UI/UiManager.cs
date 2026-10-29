using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _barra;

    public void SumarFillAmount(float amount)
    {
        _barra.fillAmount += amount;
    }
    public void RestarFillAmount(float amount)
    {
        _barra.fillAmount = amount = _barra.fillAmount - amount;
    }
    public void ColorBarra(Color myColor)
    {
        _barra.color = myColor;
    }
}