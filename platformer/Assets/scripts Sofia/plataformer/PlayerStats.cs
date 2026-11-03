using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVidaActuales = 100;
    [SerializeField] private int _puntosVidaMaximo = 100;
    [SerializeField] public UIManager _uiManager;
    [SerializeField] private int _panelPerdiste;



    public void RestarVida(int daño)
    {
        _puntosVidaActuales -= daño;

        if (_puntosVidaActuales < 0)
            _puntosVidaActuales = 0;

        Debug.Log("Vida actual: " + _puntosVidaActuales);

        if (_puntosVidaActuales <= 0)
            Debug.Log("GAME OVER");
    }


    private void Update()
    {

        if (_puntosVidaActuales >= 80)
        {
            _uiManager.ColorBarra(new Color(68f / 255f, 189f / 255f, 68f / 255f, 225f / 255f));
        }


        if (_puntosVidaActuales < 80)
        {
            _uiManager.ColorBarra(new Color(245f / 255f, 73f / 255f, 39f / 255f, 255f / 255f));
        }


        if (_puntosVidaActuales <= 40)
        {
            _uiManager.ColorBarra(new Color(189f / 255f, 15f / 255f, 15f / 255f, 255f / 255f));

            if (_puntosVidaActuales > 100)
            {
                _puntosVidaActuales = 100;
            }

            if (_puntosVidaActuales <= 0)
            {
                Destroy(this.gameObject);
            }


        }

    }
 }