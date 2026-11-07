using UnityEngine;

public class Trampa : MonoBehaviour

{
    [SerializeField] private int _daño = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats jugador = other.GetComponentInParent<PlayerStats>();
        if (jugador != null)
            jugador.RestarVida(_daño);
    }
}