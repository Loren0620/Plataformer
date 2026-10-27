using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameManager _gameManager;

    private int _vidaActual;
    private bool _escudoActivo;

    void Start()
    {
        _vidaActual = _vidaMaxima;
        _escudoActivo = false;
        ActualizarInterfaz();
        _uiManager.ActualizarEscudo(false);
    }

    public void RestarVida(int danio)
    {
        if (_vidaActual <= 0) return;

        // Escudo de un impacto: absorbe el golpe y se consume
        if (_escudoActivo)
        {
            _escudoActivo = false;
            _uiManager.ActualizarEscudo(false);
            return;
        }

        _vidaActual = Mathf.Max(0, _vidaActual - danio);
        ActualizarInterfaz();

        if (_vidaActual <= 0)
            _gameManager.Derrota();
    }

    public void RestaurarVida(int curacion)
    {
        if (_vidaActual <= 0) return;

        _vidaActual = Mathf.Min(_vidaMaxima, _vidaActual + curacion);
        ActualizarInterfaz();
    }

    public void ActivarEscudo()
    {
        _escudoActivo = true;
        _uiManager.ActualizarEscudo(true);
    }

    private void ActualizarInterfaz()
    {
        _uiManager.ActualizarVida(_vidaActual, _vidaMaxima);

        // Mismos colores que ya tenías
        if (_vidaActual >= 80)
            _uiManager.ColorBarra(new Color(68f / 255f, 189f / 255f, 68f / 255f, 1f));
        else if (_vidaActual > 40)
            _uiManager.ColorBarra(new Color(245f / 255f, 73f / 255f, 39f / 255f, 1f));
        else
            _uiManager.ColorBarra(new Color(189f / 255f, 15f / 255f, 15f / 255f, 1f));
    }
}