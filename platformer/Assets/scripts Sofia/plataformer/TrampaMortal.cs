using UnityEngine;

public class TrampaMortales : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats vidaJugador =
                collision.gameObject.GetComponent<PlayerStats>();

            if (vidaJugador != null)
            {
                vidaJugador.RestarVida(vidaJugador.VidaMaxima);
            }
            ;
        }

        Destroy(collision.gameObject);
    }
}