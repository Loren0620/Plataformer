using UnityEngine;

public class ganaste : MonoBehaviour
{
    public GameObject panelganaste;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelganaste.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
        }
    }
}