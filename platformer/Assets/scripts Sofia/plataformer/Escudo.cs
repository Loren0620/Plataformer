using UnityEngine;

// Power-up de escudo: activa la protección temporal (la duración está en PlayerStats)
public class Escudo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStats stats = other.GetComponent<PlayerStats>();
        if (stats == null) return;

        stats.ActivarEscudo();
        Destroy(gameObject); // desaparece al tocarlo
    }
}