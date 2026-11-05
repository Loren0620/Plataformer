using UnityEngine;

// Llave: visible desde el inicio, pero solo se puede recoger al tener los diamantes necesarios
public class ObjetoDesbloqueable : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Sin los diamantes suficientes, la llave no se recoge
         
        Destroy(gameObject);
    }
}