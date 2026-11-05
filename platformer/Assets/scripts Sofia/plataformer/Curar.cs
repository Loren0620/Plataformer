using UnityEngine;

public class Curar : MonoBehaviour
{
    [SerializeField] private int _curacion = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats jugador = other.GetComponentInParent<PlayerStats>();
        if (jugador == null) return;

        jugador.RestaurarVida(_curacion);
        Destroy(gameObject);
    }
}
