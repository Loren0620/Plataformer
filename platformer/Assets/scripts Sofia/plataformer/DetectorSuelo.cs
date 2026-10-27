using UnityEngine;

public class DetectorSuelo : MonoBehaviour
{
    public bool estaEnSuelo;

    private void OnTriggerStay2D(Collider2D colision)
    {
        estaEnSuelo = true;
        Debug.Log("Tocó el suelo");
    }

    private void OnTriggerExit2D(Collider2D colision)
    {
        estaEnSuelo = false;
        Debug.Log("Estoy saltando");
    }
}
