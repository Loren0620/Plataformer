
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform jugador;

    [Header("Configuración")]
    public Vector3 offset = new Vector3(0f, 1f, -10f); // distancia respecto al jugador
    public float suavizado = 5f;                       // más alto = más pegada al jugador

    [Header("Opciones")]
    public bool seguirEjeY = true;   // desactívalo si quieres que la cámara no suba/baje

    private float yInicial;

    void Start()
    {
        yInicial = transform.position.y;
    }

    // LateUpdate se ejecuta después de que el jugador se movió, evita temblores
    void LateUpdate()
    {
        if (jugador == null) return;

        Vector3 destino = jugador.position + offset;

        if (!seguirEjeY)
            destino.y = yInicial;

        transform.position = Vector3.Lerp(transform.position,destino,suavizado * Time.deltaTime);
    }
}
