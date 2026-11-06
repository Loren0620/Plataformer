
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private int _vidaActual = 100;
    [SerializeField] private int _vidaMaxima = 100;

    [Header("Escudo")]
    [SerializeField] private float _duracionEscudo = 15f;

    [Header("Tiempo del nivel")]
    [SerializeField] private float _tiempoLimite = 300f;

    [Header("Referencias")]
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameManager _gameManager;

    private bool _escudoActivo;
    private float _tiempoRestanteEscudo;
    private float _tiempoRestante;

    private bool _nivelCompletado;
    private bool _haPerdido;

    private void Start()
    {
        _vidaActual = _vidaMaxima;
        _escudoActivo = false;

        _tiempoRestante = _tiempoLimite;

        _nivelCompletado = false;
        _haPerdido = false;

        if (_uiManager == null || _gameManager == null)
        {
            Debug.LogError("Faltan referencias en PlayerStats.");
            enabled = false;
            return;
        }

        ActualizarInterfaz();

        _uiManager.ActualizarTiempo(_tiempoRestante);
        _uiManager.ActualizarEscudo(false);
    }

    private void Update()
    {
        if (_nivelCompletado || _haPerdido) return;

        // CONTADOR DEL NIVEL
        _tiempoRestante -= Time.deltaTime;

        _uiManager.ActualizarTiempo(_tiempoRestante);

        if (_tiempoRestante <= 0f)
        {
            MatarInstantaneo();
            return;
        }

        // DURACIÓN DEL ESCUDO
        if (_escudoActivo)
        {
            _tiempoRestanteEscudo -= Time.deltaTime;

            if (_tiempoRestanteEscudo <= 0f)
            {
                _escudoActivo = false;
                _uiManager.ActualizarEscudo(false);
            }
        }
    }

    // RESTAR VIDA
    public void RestarVida(int daño)
    {
        if (_haPerdido || _nivelCompletado) return;
        if (_escudoActivo || daño <= 0) return;

        _vidaActual = Mathf.Max(0, _vidaActual - daño);

        ActualizarInterfaz();

        if (_vidaActual <= 0)
        {
            DerrotarJugador();
        }
    }

    // MUERTE INSTANTÁNEA
    public void MatarInstantaneo()
    {
        if (_haPerdido || _nivelCompletado) return;

        _vidaActual = 0;

        ActualizarInterfaz();
        DerrotarJugador();
    }

    // RECUPERAR VIDA
    public void RestaurarVida(int curacion)
    {
        if (_haPerdido || _nivelCompletado) return;
        if (curacion <= 0) return;

        _vidaActual = Mathf.Min(
            _vidaMaxima,
            _vidaActual + curacion
        );

        ActualizarInterfaz();
    }

    // ACTIVAR ESCUDO
    public void ActivarEscudo()
    {
        if (_haPerdido || _nivelCompletado) return;

        _escudoActivo = true;
        _tiempoRestanteEscudo = _duracionEscudo;

        _uiManager.ActualizarEscudo(true);
    }

    // COMPLETAR NIVEL
    public void CompletarNivel()
    {
        if (_haPerdido || _nivelCompletado) return;

        _nivelCompletado = true;

        _gameManager.CompletarNivel();
    }

    // DERROTA
    private void DerrotarJugador()
    {
        if (_haPerdido || _nivelCompletado) return;

        _haPerdido = true;

        Debug.Log("¡EL JUGADOR HA PERDIDO!");

        _gameManager.Derrota();
    }

    // ACTUALIZAR INTERFAZ
    private void ActualizarInterfaz()
    {
        _uiManager.ActualizarVida(
            _vidaActual,
            _vidaMaxima
        );

        if (_vidaActual >= 80)
        {
            _uiManager.ColorBarra(
                new Color(68f / 255f, 189f / 255f, 68f / 255f)
            );
        }
        else if (_vidaActual > 40)
        {
            _uiManager.ColorBarra(
                new Color(245f / 255f, 73f / 255f, 39f / 255f)
            );
        }
        else
        {
            _uiManager.ColorBarra(
                new Color(189f / 255f, 15f / 255f, 15f / 255f)
            );
        }
    }
}
