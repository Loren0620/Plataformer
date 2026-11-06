
using UnityEngine;

public class TrampaMortal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = colision.gameObject.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.MatarInstantaneo();
            }
            else
            {
                Debug.LogError("No se encontró PlayerStats en el jugador.");
            }
        }
    }
}

