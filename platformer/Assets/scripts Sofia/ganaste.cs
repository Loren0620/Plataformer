
using UnityEngine;

public class ganaste : MonoBehaviour
{
    public GameObject panelganaste;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelganaste.SetActive(true);

            FindObjectOfType<PlayerStats>().CompletarNivel();

            Debug.Log("¡Nivel completado!");

            Time.timeScale = 0;
        }
    }
}

