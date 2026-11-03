using UnityEngine;

public class EscudosHongos : MonoBehaviour

{
    [SerializeField] private int _curacion = 20;
    [SerializeField] private bool _daEscudo = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats jugador = other.GetComponentInParent<PlayerStats>();
        if (jugador == null) return;   // lo tocó otra cosa, no el jugador

        jugador.RestaurarVida(_curacion);

        if (_daEscudo)
            jugador.ActivarEscudo();

        Destroy(gameObject);           // desaparece
    }
}
