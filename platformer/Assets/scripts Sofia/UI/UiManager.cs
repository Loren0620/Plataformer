
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

    // ACTUALIZAR VIDA
    public void ActualizarVida(float actual, float maxima)
    {
        if (_barraVida == null) return;

        _barraVida.fillAmount = maxima > 0
            ? Mathf.Clamp01(actual / maxima)
            : 0f;
    }

    // CAMBIAR COLOR DE LA BARRA
    public void ColorBarra(Color color)
    {
        if (_barraVida == null) return;

        _barraVida.color = color;
    }

    // ACTUALIZAR PUNTOS
    public void ActualizarPuntos(int puntos)
    {
        if (_textoPuntos == null) return;

        _textoPuntos.text = $"Puntos: {puntos}";
    }

    // ACTUALIZAR TIEMPO
    public void ActualizarTiempo(float segundos)
    {
        if (_textoTiempo == null) return;

        int s = Mathf.CeilToInt(Mathf.Max(0f, segundos));

        _textoTiempo.text = $"{s / 60:00}:{s % 60:00}";
    }

    // ACTIVAR O DESACTIVAR ESCUDO
    public void ActualizarEscudo(bool activo)
    {
        if (_iconoEscudo == null) return;

        _iconoEscudo.SetActive(activo);
    }

    // PANEL DE INICIO
    public void MostrarInicio(bool mostrar)
    {
        if (_panelInicio != null)
            _panelInicio.SetActive(mostrar);
    }

    // PANEL DE PAUSA
    public void MostrarPausa(bool mostrar)
    {
        if (_panelPausa != null)
            _panelPausa.SetActive(mostrar);
    }

    // PANEL DE DERROTA
    public void MostrarDerrota()
    {
        if (_panelDerrota == null)
        {
            Debug.LogError("No se ha asignado el panel de derrota.");
            return;
        }

        _panelDerrota.SetActive(true);
    }

    // PANEL DE VICTORIA
    public void MostrarVictoria()
    {
        if (_panelVictoria == null)
        {
            Debug.LogError("No se ha asignado el panel de victoria.");
            return;
        }

        _panelVictoria.SetActive(true);
    }
}
