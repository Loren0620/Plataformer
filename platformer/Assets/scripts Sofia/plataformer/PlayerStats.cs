
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   [SerializeField] private int _vidaActual = 100;
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private float _duracionEscudo = 15f;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameManager _gameManager;

    public GameObject panelPerdiste;
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
        if (_escudoActivo) return;

        _vidaActual = Mathf.Max(0, _vidaActual - daño);

        ActualizarInterfaz();

        if (_vidaActual <= 0)
        {
            _gameManager.Derrota();
        }
    }

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

        _vidaActual = Mathf.Min(
            _vidaMaxima,
            _vidaActual + curacion
        );

        ActualizarInterfaz();
    }

    public void ActivarEscudo()
    {
        if (_vidaActual <= 0) return;

        _escudoActivo = true;
        _tiempoRestanteEscudo = _duracionEscudo;

        _uiManager.ActualizarEscudo(true);
    }

    private void ActualizarInterfaz()
    {
        _uiManager.ActualizarVida(_vidaActual, _vidaMaxima);

        if (_vidaActual >= 80)
        {
            _uiManager.ColorBarra(
                new Color(68f / 255f, 189f / 255f, 68f / 255f, 1f)
            );
        }
        else if (_vidaActual > 40)
        {
            _uiManager.ColorBarra(
                new Color(245f / 255f, 73f / 255f, 39f / 255f, 1f)
            );
        }
        else
        {
            _uiManager.ColorBarra(
                new Color(189f / 255f, 15f / 255f, 15f / 255f, 1f)
            );
            if (_vidaActual > 100)
            {
                _vidaActual = 100 ;
            }

            if (_vidaActual <= 0)
            {
                Destroy(this.gameObject);
            }

            if (_vidaActual <= 0)
            {
                panelPerdiste.SetActive(true);
                
            }
        }
    }
}
