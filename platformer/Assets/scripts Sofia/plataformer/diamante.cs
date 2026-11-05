using UnityEngine;

// Diamante: suma puntos, cuenta para desbloquear la llave y desaparece al tocarlo
public class Diamante : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Destroy(gameObject);
    }
}