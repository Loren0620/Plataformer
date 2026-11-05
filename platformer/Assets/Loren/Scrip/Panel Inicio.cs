using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loren");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
