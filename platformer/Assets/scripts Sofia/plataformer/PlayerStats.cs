using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private float _duracionEscudo = 1f;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameManager _gameManager;

    private int _vidaActual;
    private bool _escudoActivo;
    private float _tiempoRestanteEscudo;

    void Start()
    {
        _vidaActual = _vidaMaxima;
        _escudoActivo = false;
        ActualizarInterfaz();
        _uiManager.ActualizarEscudo(false);
    }

    void Update()
    {
        if (!_escudoActivo) return;

        // Time.deltaTime vale 0 en pausa, así que el escudo no se gasta mientras el juego está pausado
        _tiempoRestanteEscudo -= Time.deltaTime;

        if (_tiempoRestanteEscudo <= 0f)
        {
            _escudoActivo = false;
            _uiManager.ActualizarEscudo(false);
        }
    }

    public void RestarVida(int daño)
    {
        if (_vidaActual <= 0) return;

        // Escudo temporal: mientras esté activo no se recibe daño
        if (_escudoActivo) return;

        _vidaActual = Mathf.Max(0, _vidaActual - daño);
        ActualizarInterfaz();

        if (_vidaActual <= 0)
            _gameManager.Derrota();
    }

    // Muerte instantánea (trampas mortales): el escudo también protege de ella
    public void MatarInstantaneo()
    {
        if (_vidaActual <= 0) return;
        if (_escudoActivo) return;

        _vidaActual = 0;
        ActualizarInterfaz();
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
        // Si ya había un escudo, recoger otro reinicia los 15 segundos
        _escudoActivo = true;
        _tiempoRestanteEscudo = _duracionEscudo;
        _uiManager.ActualizarEscudo(true);
    }

    private void ActualizarInterfaz()
    {
        _uiManager.ActualizarVida(_vidaActual, _vidaMaxima);

        if (_vidaActual >= 80)
            _uiManager.ColorBarra(new Color(68f / 255f, 189f / 255f, 68f / 255f, 1f));
        else if (_vidaActual > 40)
            _uiManager.ColorBarra(new Color(245f / 255f, 73f / 255f, 39f / 255f, 1f));
        else
            _uiManager.ColorBarra(new Color(189f / 255f, 15f / 255f, 15f / 255f, 1f));
    }
}
