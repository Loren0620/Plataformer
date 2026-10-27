using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private Image _barraVida;
    [SerializeField] private TMP_Text _textoPuntos;
    [SerializeField] private TMP_Text _textoTiempo;
    [SerializeField] private GameObject _iconoEscudo;

    [Header("Paneles")]
    [SerializeField] private GameObject _panelInicio;
    [SerializeField] private GameObject _panelPausa;
    [SerializeField] private GameObject _panelDerrota;
    [SerializeField] private GameObject _panelVictoria;

    // PlayerStats le pasa el valor ya calculado; aquí solo se dibuja
    public void ActualizarVida(float actual, float maxima)
    {
        _barraVida.fillAmount = actual / maxima;
    }

    public void ColorBarra(Color color) => _barraVida.color = color;

    public void ActualizarPuntos(int puntos) => _textoPuntos.text = $"Puntos: {puntos}";

    public void ActualizarTiempo(float segundos)
    {
        int s = Mathf.CeilToInt(Mathf.Max(0f, segundos));
        _textoTiempo.text = $"{s / 60:00}:{s % 60:00}";
    }

    public void ActualizarEscudo(bool activo) => _iconoEscudo.SetActive(activo);

    public void MostrarInicio(bool mostrar) => _panelInicio.SetActive(mostrar);
    public void MostrarPausa(bool mostrar) => _panelPausa.SetActive(mostrar);
    public void MostrarDerrota() => _panelDerrota.SetActive(true);
    public void MostrarVictoria() => _panelVictoria.SetActive(true);
}
