
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;


    public void ComenzarNivel()
    {
        Time.timeScale = 1f;
        _uiManager.MostrarInicio(false);
    }

    public void CargarEscena(int indiceEscena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(indiceEscena);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SalirAlMenu()
    {
        CargarEscena(0);
    }

    public void PausarElJuego()
    {
        Time.timeScale = 0f;
    }

    public void ReanudarElJuego()
    {
        Time.timeScale = 1f;
    }

    // DERROTA
    public void Derrota()
    {
        Time.timeScale = 0f;
        _uiManager.MostrarDerrota();
    }

    // VICTORIA
    public void CompletarNivel()
    {
        Time.timeScale = 0f;
        _uiManager.MostrarVictoria();
    }
}
