using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVidaActuales = 100;
    [SerializeField] private int _puntosVidaMaximo = 100;
    [SerializeField] public UIManager _uiManager;
    [SerializeField] private int _panelPerdiste;

    

    public GameObject panelPerdiste;

    private int _restaurarVida = 10;
    public void RestarVida(int daño)
    {
        _puntosVidaActuales = _puntosVidaActuales - daño;

    }
    public void RestaurarVida(int heal)
    {
        _puntosVidaActuales = _puntosVidaActuales + _restaurarVida;

    }
   

    private void Update()
    {
        
        if (_puntosVidaActuales>= 80)
        {
            _uiManager.ColorBarra(new Color (68f / 255f, 189f / 255f, 68f / 255f, 225f / 255f));
        }

        
        if (_puntosVidaActuales < 80)
        {
            _uiManager.ColorBarra(new Color (245f / 255f, 73f / 255f, 39f / 255f, 255f / 255f));
        }

        
        if (_puntosVidaActuales <= 40)
        {
            _uiManager.ColorBarra(new Color (189f / 255f, 15f / 255f, 15f / 255f, 255f / 255f)) ;

            if (_puntosVidaActuales > 100)
            {
                _puntosVidaActuales = 100 ;
            }

            if (_puntosVidaActuales <= 0)
            {
                Destroy(this.gameObject);
            }

            if (_puntosVidaActuales <= 0)
            {
                panelPerdiste.SetActive(true);
                
            }
        }
    

    }
}


