using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    void Start()
    {
        Time.timeScale = 0f;
        _uiManager.MostrarInicio(true);
    }

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

    public void Derrota()
    {
        Time.timeScale = 0f;
        _uiManager.MostrarDerrota();
    }
}